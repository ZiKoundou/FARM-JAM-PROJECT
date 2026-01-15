using System.Collections.Generic;
using UnityEngine;
public class ShooterPlant : Plant
{
    private List<Enemy> inRange = new List<Enemy>();
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if not an enemy, ignore
        if(!collision.CompareTag("Enemy")) return;
        //grab enemy componenet
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null) return;
        //add to a list
        
        if (!inRange.Contains(enemy))
        {
            inRange.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //check if enemy in list
        if(!collision.CompareTag("Enemy")) return;

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null) return;
        
        //remove it from the list to a list
        if (inRange.Contains(enemy))
        {
            inRange.Remove(enemy);
        }
    }

    public void Shoot(Enemy enemy)
    {
        GameObject bulletObject =  Instantiate(stages[currentStageIndex].projectilePrefab, gameObject.transform);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetTarget(enemy.transform);
        }
        
    }

    void FiringActive()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire > fireRate)
        {
            if (inRange.Count > 0)
            {
                Shoot(inRange[0]);
                timeUntilFire = 0;
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Active 
        if(!isPlaced) return;
        FiringActive();
    }

}
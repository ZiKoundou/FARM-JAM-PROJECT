using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate;
    private float timeUntilFire;
    [SerializeField] private List<Enemy> inRange = new List<Enemy>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // get the collider of the plant
    // on trigger, instatiate and apply force vector in that direction from the origin
    //
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
        GameObject bulletObject =  Instantiate(bulletPrefab, gameObject.transform);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetTarget(enemy.transform);
        }
        
    }
    // Update is called once per frame
    void Update()
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
}

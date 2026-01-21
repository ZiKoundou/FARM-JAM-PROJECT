using System.Collections.Generic;
using UnityEngine;
public class ShooterPlant : Plant
{

    private List<Enemy> inRange = new List<Enemy>();
    private float damage;
    private float fireRate;
    private float attackRange;
    private GameObject projectilePrefab;
    private float timeUntilFire;
    #region Enemy Detection
    
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
    #endregion
    #region Shooting bullets
    public void Shoot(Enemy enemy)
    {
        GameObject bulletObject =  Instantiate(projectilePrefab, gameObject.transform);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetTarget(enemy.transform);
        }
        
    }
    #endregion
    #region Fire Timing
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
    #endregion
    #region Unity Callbacks
    void Update()
    {
        // Active 
        if(!isPlaced) return;
        FiringActive();
    }
    #endregion
    #region Applying stats
    protected override void OnStageApplied()
    {
        // Apply the current stage's stats to this plant
        damage = stages[currentStageIndex].damage; //no sure i need this because the damage is already on the bullet lowkey...
        fireRate = stages[currentStageIndex].fireRate;
        attackRange = stages[currentStageIndex].range;

        // Update the collider radius
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if(collider != null)
        {
            collider.radius = attackRange;
        }

        // Update projectile prefab if it changes per stage
        projectilePrefab = stages[currentStageIndex].projectilePrefab;
    }
    #endregion
}
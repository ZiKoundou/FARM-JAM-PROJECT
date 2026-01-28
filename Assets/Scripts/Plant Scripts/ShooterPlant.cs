using System.Collections.Generic;
using UnityEngine;
public class ShooterPlant : Plant
{

    
    private float damage;
    private float fireRate;
    private float attackRange;
    private GameObject projectilePrefab;
    private float timeUntilFire;

    #region Shooting bullets
    public void Shoot(Enemy enemy)
    {
        AudioManager.instance.PlaySFX("SHOOT");
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
        CircleCollider2D collider = GetComponentInChildren<CircleCollider2D>();
        if(collider != null)
        {
            collider.gameObject.transform.localScale = new Vector3(attackRange, attackRange, 1);
        }

        // Update projectile prefab if it changes per stage
        projectilePrefab = stages[currentStageIndex].projectilePrefab;
    }
    #endregion
}
using UnityEngine;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
//detects in range 
//attacks
//set collider active around for every enemy around, do dmg
public class AoePlant : Plant
{
    float timeUntilFire;
    float fireRate;
    private float damage;
    
    private float attackRange;
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

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void FiringActive()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire > fireRate)
        {
            if (inRange.Count > 0)
            {
                Attack();
                timeUntilFire = 0;
            }
            
        }
    }

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

    }
    void Update()
    {
        // Active 
        if(!isPlaced) return;
        FiringActive();
    }
}


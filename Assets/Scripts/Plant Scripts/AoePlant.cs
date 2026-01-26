using UnityEngine;
using System.Numerics;

//detects in range 
//attacks
//set collider active around for every enemy around, do dmg
public class AoePlant : Plant
{
    float timeUntilFire;
    float fireRate;
    private float damage;

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
        Gizmos.DrawWireSphere(transform.position, range/2);
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
        range = stages[currentStageIndex].range;

        // Update the collider radius
        CircleCollider2D collider = GetComponentInChildren<CircleCollider2D>();
        if(collider != null)
        {
            collider.gameObject.transform.localScale = new UnityEngine.Vector3(range, range, 1);
        }

    }
    void Update()
    {
        // Active 
        if(!isPlaced) return;
        FiringActive();
    }
}


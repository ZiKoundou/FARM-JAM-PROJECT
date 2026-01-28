using UnityEngine;
using System.Numerics;
using System.Collections;
using UnityEngine.Animations;

//detects in range 
//attacks
//set collider active around for every enemy around, do dmg
public class AoePlant : Plant
{
    float timeUntilFire;
    float fireRate;
    private float damage;
    [SerializeField] private GameObject hitEffect;
    void Attack()
    {
        
        StartCoroutine(ShowAoEEffect());
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.parent.position, range);
        AudioManager.instance.PlaySFX("SHOOT");
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponentInChildren<Health>()?.TakeDamage(damage);
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

    IEnumerator ShowAoEEffect()
    {
        if(hitEffect == null) yield break;
        
        hitEffect.SetActive(true);
        hitEffect.transform.localScale = new UnityEngine.Vector3(range, range, 1);

        // quick scale-up / fade-out effect
        float duration = 0.2f;
        float elapsed = 0f;
        UnityEngine.Vector3 initialScale = hitEffect.transform.localScale * 0.8f;
        UnityEngine.Vector3 finalScale = hitEffect.transform.localScale;

        SpriteRenderer sr = hitEffect.GetComponent<SpriteRenderer>();
        Color initialColor = sr.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            hitEffect.transform.localScale = UnityEngine.Vector3.Lerp(initialScale, finalScale, t);
            sr.color = Color.Lerp(initialColor, targetColor, t);

            yield return null;
        }

        sr.color = initialColor;
        hitEffect.SetActive(false);
    }
}


using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Transform checkPoint;

    [HideInInspector] public EnemyHealth enemyHealth;
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Start()
    {
        checkPoint = EnemyManager.main.checkPoints[index];
    }

    // Update is called once per frame
    void Update()
    {
        //if u reach the end of the level
        if(index >= EnemyManager.main.checkPoints.Length)
        {
            //for now just kill the enemy
            Debug.Log("killing enemy");
            enemyHealth.health.Die();
            return;
        }
        checkPoint = EnemyManager.main.checkPoints[index];
        
        // Debug.Log("wave index "+ index);
        if(Vector2.Distance(checkPoint.transform.position, gameObject.transform.position)<= 0.1f)
        {
            index++;
        }
    }

    void FixedUpdate()
    {
        // move rigidbody towards the position of the checkpoint
        // get the direction by subtracting the position of the checkpoint and the position of the enemy
        Vector2 direction = (checkPoint.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }
}

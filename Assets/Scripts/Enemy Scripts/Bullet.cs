using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Parameters")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform target; 
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        //set direction
        Vector2 direction = (target.position-transform.position).normalized;

        //set rigid body speed
        rb.linearVelocity = direction * bulletSpeed;
    }
}

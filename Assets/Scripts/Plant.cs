using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
public class Plant : MonoBehaviour
{
    [Header("Plant Attributes")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate;
    // [SerializeField] private GameObject plantManagerGameobject;
    // private PlantManager plantManager;
    private float timeUntilFire;
    [SerializeField] private List<Enemy> inRange = new List<Enemy>();
    //turn off range outline
    [SerializeField] private SpriteRenderer rangeOutine;
    public  enum PlacementState{
        Placing,
        Placed,
        Cancelled
    }
    PlacementState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        state = PlacementState.Placing;
        // rangeOutine = GetComponentInChildren<SpriteRenderer>();
        // plantManager = plantManagerGameobject.GetComponent<PlantManager>();
    }

    public void FollowMouse()
    {
        UnityEngine.Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        UnityEngine.Vector3 worldPos  = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        worldPos.z = 0;
        transform.position = worldPos;
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

        switch (state)
        {
            case PlacementState.Placing:
                // code when state == Placing
                FollowMouse();
                // if u click
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    state = PlacementState.Placed;
                    rangeOutine.enabled = false;
                    //add to list
                    // plantManager.AddToList();
                    
                }else if (Mouse.current.rightButton.wasPressedThisFrame)
                {
                    state = PlacementState.Cancelled;
                }
                break;

            case PlacementState.Placed:
                // code when state == Placed
                FiringActive();
                break;

            case PlacementState.Cancelled:
                // code when state == Cancelled
                Destroy(gameObject);
                break; 
        }
    }
}

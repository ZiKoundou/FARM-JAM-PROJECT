using UnityEngine;

public class RangeDetection : MonoBehaviour
{
    private Plant plant;

    private void Awake()
    {
        plant = GetComponentInParent<Plant>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            plant.AddEnemyToList(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            plant.RemoveEnemyFromList(enemy);
        }
    }
}
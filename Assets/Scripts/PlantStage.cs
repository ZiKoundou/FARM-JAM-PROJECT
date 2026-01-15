using UnityEngine;

[System.Serializable]
public class PlantStage
{
    public string name;
    public Sprite sprite;
    [Header("Stats")]
    public float damage;
    public float fireRate;
    public float range;

    [Header("Projectile")]
    public GameObject projectilePrefab;

    [Header("Growth")]
    public float growthRequired;
}

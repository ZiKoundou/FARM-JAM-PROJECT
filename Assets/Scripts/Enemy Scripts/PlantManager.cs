using System.Collections.Generic;
using UnityEngine;


public class PlantManager : MonoBehaviour
{
    public static PlantManager instance;
    [SerializeField] private List<Plant> placed = new List<Plant>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] plants;
    Vector3 spawnPos = new Vector3(100f, 100f, 1f); // off-screen coordinates
    void Awake()
    {
        if (instance == null)
        {
            instance = this;  // set the instance
            DontDestroyOnLoad(gameObject); // optional: persist across scenes
        }
        else
        {
            Destroy(gameObject); // only allow one
        }
    }
    // function that adds to list after placing
    // function that removes from list after harvest
    // function that grows all plants from list

    //function for each type of plant 
    public void PickSunFlower()
    {
        
        if(CurrencyManager.instance.TryBuy(plants[0].GetComponentInChildren<Plant>().Cost) == false){
            Debug.Log("Not enough currency to buy plant");
            return;
        }
        Instantiate(plants[0], spawnPos, Quaternion.identity);
        // by default should be placing on instatiation
    
    }
    public void PickAoeFlower()
    {
        if(CurrencyManager.instance.TryBuy(plants[1].GetComponentInChildren<Plant>().Cost) == false){
            Debug.Log("Not enough currency to buy plant");
            return;
        }
        Instantiate(plants[1], spawnPos, Quaternion.identity);
        // by default should be placing on instatiation
    
    }

    public void PickMushroomFlower()
    {
        if(CurrencyManager.instance.TryBuy(plants[2].GetComponentInChildren<Plant>().Cost) == false){
            Debug.Log("Not enough currency to buy plant");
            return;
        }
        Instantiate(plants[2], spawnPos, Quaternion.identity);
        // by default should be placing on instatiation
    
    }

    public void PickFireFlower()
    {
        if(CurrencyManager.instance.TryBuy(plants[3].GetComponentInChildren<Plant>().Cost) == false){
            Debug.Log("Not enough currency to buy plant");
            return;
        }
        Instantiate(plants[3], spawnPos, Quaternion.identity);
        // by default should be placing on instatiation
    
    }
    public void AddToList(Plant plant)
    {
        placed.Add(plant);
    }

    public void GrowAll()
    {
        //loop through each and aaddgrowth
        foreach (Plant p in placed)
        {
            p.AddGrowth(1);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

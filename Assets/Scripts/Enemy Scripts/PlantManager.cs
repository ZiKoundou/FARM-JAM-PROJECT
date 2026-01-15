using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class PlantManager : MonoBehaviour
{
    public static PlantManager instance;
    [SerializeField] private List<Plant> placed = new List<Plant>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] plants;
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
    public void Pick()
    {
        Instantiate(plants[0]);

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

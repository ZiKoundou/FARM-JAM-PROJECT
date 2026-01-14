using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class PlantManager : MonoBehaviour
{
    [SerializeField] private List<Plant> placed = new List<Plant>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject plant;
    void Start()
    {
        
    }
    // function that adds to list after placing
    // function that removes from list after harvest
    // function that grows all plants from list 
    public void Pick()
    {
        Instantiate(plant);

        // by default should be placing on instatiation
    
    }

    public void AddToList(Plant plant)
    {
        placed.Add(plant);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
public class PlantSelection : MonoBehaviour
{
    [Header("Plant Placement Attributes")]
    private SpriteRenderer rangeOutine;
    private bool isSelected = false;
    Plant currentPlant;
    

    void Start()
    {
        currentPlant = GetComponentInParent<Plant>();
        rangeOutine = GetComponent<SpriteRenderer>();
    }
    public void Select()
    {
        //turn on sprite render
        if(isSelected) return;
        gameObject.transform.localScale = new Vector3(2*currentPlant.Range,2*currentPlant.Range,1);
        isSelected = true;
        rangeOutine.enabled = isSelected;
        

    }

    public void Deselect()
    {
        //turn off sprite render
        if(!isSelected) return;
        gameObject.transform.localScale = new Vector3(2*currentPlant.Range,2*currentPlant.Range,1);
        isSelected = false;
        rangeOutine.enabled = isSelected;
    }

    private void OuseDown()
    {
        
    }
}
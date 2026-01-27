using UnityEngine;
using UnityEngine.InputSystem;
public class PlantSelectionManager : MonoBehaviour
{
    public static PlantSelectionManager instance;
    [SerializeField] private Plant selectedPlant;
    [SerializeField] private LayerMask plantLayer;

    void Awake()
    {
        instance = this;
    }

    void HandleClick()
    {
        // get screenPos and check if it hits a plant
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 rayPos = new Vector2(worldPos.x, worldPos.y);

        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f, plantLayer);

        if (hit.collider != null)
        {
            Plant plant = hit.collider.GetComponentInChildren<Plant>();
            if (plant != null)
            {
                SelectPlant(plant);
                return;
            }
        }

        // clicked empty space
        DeselectPlant();
    }
    public void SelectPlant(Plant plant)
    {
        if (selectedPlant == plant) return;// already selected

        if (selectedPlant != null)
            selectedPlant.GetComponentInChildren<PlantSelection>().Deselect();

        selectedPlant = plant;
        selectedPlant.GetComponentInChildren<PlantSelection>().Select();
    }
    public void DeselectPlant()
    {
        Debug.Log("deselctin plant fr bruh");
        if (selectedPlant != null)
        {
            
            selectedPlant.GetComponentInChildren<PlantSelection>().Deselect();
            selectedPlant = null;
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }
    }

}

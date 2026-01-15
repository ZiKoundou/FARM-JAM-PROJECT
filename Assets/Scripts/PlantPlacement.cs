using UnityEngine;
using UnityEngine.InputSystem;
public class PlantPlacement : MonoBehaviour
{
    #region Fields
    [Header("Plant Placement Attributes")]
    [SerializeField] private SpriteRenderer rangeOutine;
    public enum PlacementState{
        Placing,
        Placed,
        Cancelled
    }
    PlacementState state;
    private Plant currentPlant;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = PlacementState.Placing;
        currentPlant = GetComponent<Plant>();
    }

    // Update is called once per frame
    void Update()
    {
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
                currentPlant.OnPlaced();
                break;

            case PlacementState.Cancelled:
                // code when state == Cancelled
                Destroy(gameObject);
                break; 
        }
    }

    void FollowMouse()
    {
        UnityEngine.Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        UnityEngine.Vector3 worldPos  = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        worldPos.z = 0;
        transform.position = worldPos;
    }
}

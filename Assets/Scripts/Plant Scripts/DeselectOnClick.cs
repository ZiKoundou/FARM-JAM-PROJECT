using UnityEngine;

public class DeselectOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("clickin on the thing");
        PlantSelectionManager.instance.DeselectPlant();
    }
}

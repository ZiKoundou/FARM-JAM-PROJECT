using UnityEngine;
public class UI : MonoBehaviour
{
    public GameObject TutorialWindow;
    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }
}
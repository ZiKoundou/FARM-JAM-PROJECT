using UnityEngine;
public class UI : MonoBehaviour
{
    public GameObject TutorialWindow;
    public void CloseWindow(GameObject window)
    {
        AudioManager.instance.PlaySFX("BACKCLICK");
        window.SetActive(false);
    }

    public void OpenWindow(GameObject window)
    {
        AudioManager.instance.PlaySFX("CLICK");
        window.SetActive(true);
    }
}
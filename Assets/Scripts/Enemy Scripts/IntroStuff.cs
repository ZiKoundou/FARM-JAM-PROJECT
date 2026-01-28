using Unity.VectorGraphics;
using UnityEngine;

public class IntroStuff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic("INTRO");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextSceneOnClick()
    {
        AudioManager.instance.PlaySFX("CLICK");
        SceneController.instance.LoadNextScene();
    }
}

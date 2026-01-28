using UnityEngine;

public class PlayCalm : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic("CALM1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

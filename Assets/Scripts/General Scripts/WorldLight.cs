using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    public float duration;
    [SerializeField] private Gradient gradient;
    private Light2D _light;
    private float _startTime;
    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    private void Update()
    {
        //just gets the time that has elapsed
        float timeElapsed = Time.time - _startTime;
        //i dont get this mathlol it looks insane
        float percentage = Mathf.Sin(timeElapsed/duration*Mathf.PI *2) * 0.5f+0.5f;//makes a sine function from 0 - 1
        percentage = Mathf.Clamp01(percentage);
        _light.color = gradient.Evaluate(percentage);
    }
}
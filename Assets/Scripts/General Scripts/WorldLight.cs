using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    public static WorldLight instance;
    [SerializeField] private Gradient gradient;
    [SerializeField] private float transitionDuration = 2f;

    private Light2D _light;
    private float _targetPercentage = 0f; // where the gradient should be (0-1)
    private float _currentPercentage = 0f; // current gradient position
    private bool _isTransitioning {get; set;} = false;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _currentPercentage = 0f;
        _light.color = gradient.Evaluate(_currentPercentage);
        instance = this;
    }

    private void Update()
    {
        if (_isTransitioning)
        {
            // Move currentPercentage toward targetPercentage smoothly
            _currentPercentage = Mathf.MoveTowards(_currentPercentage, _targetPercentage, Time.deltaTime / transitionDuration);
            _light.color = gradient.Evaluate(_currentPercentage);

            // Stop transitioning if reached
            if (Mathf.Approximately(_currentPercentage, _targetPercentage))
                _isTransitioning = false;
        }
    }
    public bool GetTransition()
    {
        return _isTransitioning;
    }
    // Call this when the wave starts
    public void NightTransition()
    {
        _targetPercentage = 1f; // gradient goes to end
        _isTransitioning = true;
    }

    // Call this when the wave ends
    public void DayTransition()
    {
        _targetPercentage = 0f; // gradient goes back to start
        _isTransitioning = true;
    }

    // Optional: reset light immediately
    public void ResetLight()
    {
        _currentPercentage = 0f;
        _targetPercentage = 0f;
        _isTransitioning = false;
        _light.color = gradient.Evaluate(_currentPercentage);
    }
}

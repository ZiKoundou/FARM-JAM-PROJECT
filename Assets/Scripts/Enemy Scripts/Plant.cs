using UnityEngine;
using UnityEngine.InputSystem;
public class Plant : MonoBehaviour
{
    [Header("plant attributes")]
    public GameObject projectile;

    public float projectileSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        Instantiate(projectile);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

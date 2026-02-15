using TMPro;
using UnityEngine;
using UnityEngine.UI;

// [ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
// Tooltip script to manage the display of tooltips in the UI
// Uses One centralized TooltipSystem to show/hide tooltips
{
    [Header("UI References")]
    public TextMeshProUGUI headerField;// text area for header
    public TextMeshProUGUI contentField;// text area for content
    public LayoutElement layoutElement;// layout element for resizing background box
    public int characterWrapLimit;// number of characters before text wraps to next line
    public Vector2 offset;
    Animator tooltipAnimator;
    RectTransform rectTransform;// rect transform of tooltip
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        tooltipAnimator = GetComponent<Animator>();
    }

    public void SetText(string header = "", string content = "")
    {
        gameObject.SetActive(true);// activate tooltip game object
        contentField.text = content;// set content text
        
        tooltipAnimator?.Play("Tooltip_Appear");//play animation if animator is assigned
        //-------------------------------------------------//
        //if no header passed in, do not show header text
        //-------------------------------------------------//
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        //-------------------------------------------------//

        //limit if the content or header text is longer than the character wrap limit
        if(headerField.text.Length > characterWrapLimit || contentField.text.Length > characterWrapLimit)
        {
            layoutElement.enabled = true;
        }
        else
        {
            layoutElement.enabled = false;
        }
    }

    void Update()
    {
        SetToMousePosition();
    }

    void SetToMousePosition()
    {
        // adjust pivot based on mouse position to keep tooltip on screen
        Vector2 position = Input.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;
        rectTransform.pivot = new Vector2(pivotX, pivotY);

        transform.position = position + offset;// set tooltip position to mouse position + offset
    }

}


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    // header and content for the tooltip
    public string header;// header text
    [TextArea(5, 10)]
    public string content;// text area for content
    public float appearDelay = 0.5f;// delay before tooltip appears
    Coroutine appearCoroutine;// to hold reference to the coroutine

    // show tooltip on pointer enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        appearCoroutine = StartCoroutine(ShowTooltipAfterDelay());
        
    }

    // hide tooltip on pointer exit
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
        CancelTooltipAfterDelay();
    }

    IEnumerator ShowTooltipAfterDelay()
    {
        yield return new WaitForSeconds(appearDelay);
        TooltipSystem.Show(header, content);
    }

    void CancelTooltipAfterDelay()
    {
        if (appearCoroutine != null)
        {
            StopCoroutine(appearCoroutine);
            appearCoroutine = null; // optional, clears reference
            Debug.Log("Coroutine canceled!");
        }
    }

}
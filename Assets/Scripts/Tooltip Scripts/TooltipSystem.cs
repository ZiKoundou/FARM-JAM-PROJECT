using UnityEngine;
public class TooltipSystem: MonoBehaviour
{
    private static TooltipSystem instance; // singleton instance
    public Tooltip tooltip;// reference to Tooltip component
    public void Awake()
    {
        instance = this;
    }

    // show tooltip with specified header and content
    public static void Show(string header, string content)
    {
        instance.tooltip.SetText(header, content);
        instance.tooltip.gameObject.SetActive(true);
    }

    // hide tooltip
    public static void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
    
}
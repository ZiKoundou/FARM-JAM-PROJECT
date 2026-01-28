using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
public class ClickCycleUI : MonoBehaviour
{
    public Image displayImage;
    public TMP_Text displayText;

    public Sprite[] sprites;
    [TextArea] public string[] descriptions;

    private int index = 0;

    public void OnClick()
    {
        AudioManager.instance.PlaySFX("CLICK");
        StartCoroutine(TrasitionSequence());
    }

    public void NextSlide()
    {
        index++;
        //update gui
        //fade in
        if (index >= sprites.Length)
        {
            SceneController.instance.LoadNextScene();
        }
    
    }


    public void UpdateUI()
    {
        displayImage.sprite = sprites[index];
        displayText.text = descriptions[index];

    }
    IEnumerator TrasitionSequence()
    {
        yield return StartCoroutine(ScreenFader.instance.FadeOut());
        NextSlide();
        UpdateUI();
        yield return StartCoroutine(ScreenFader.instance.FadeIn());
    }
}

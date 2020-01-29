using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class InteractionHint : FadeGraphic
{
    private Text interactionHint;

    void Start()
    {
        interactionHint = GetComponent<Text>();    
    }

    public void DisplayHint(string text, float visibleTime = 3f, float fadeTime = 1.5f)
    {
        if (interactionHint.text != text)
        {
            StopAllCoroutines();
            interactionHint.text = "";
        }
        StartCoroutine(ShowHintRoutine(text, fadeTime));
    }

    /*public void HideHint(float fadeTime = .2f)
    {
        StartCoroutine(FadeOutHint(fadeTime));
    }*/

    private IEnumerator ShowHintRoutine(string text, float fadeTime)
    {
        interactionHint.text = text;
        FadeIn(interactionHint, fadeTime);
        yield return new WaitForSeconds(2f);
        FadeOut(interactionHint, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        interactionHint.text = "";
    }
}

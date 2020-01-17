using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionHint : FadeText
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
        ShowHintRoutine(text, fadeTime);
    }

    public void HideHint(float fadeTime = 1.5f)
    {
        StartCoroutine(FadeOutHint(fadeTime));
    }

    private void ShowHintRoutine(string text, float fadeTime)
    {
        interactionHint.text = text;
        FadeIn(interactionHint, fadeTime);
    }

    private IEnumerator FadeOutHint(float fadeTime)
    {
        FadeOut(interactionHint, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        interactionHint.text = "";
    }
}

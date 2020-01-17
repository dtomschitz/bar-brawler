using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    public void FadeIn(Text text, float time)
    {
        StartCoroutine(FadeInRoutine(text, time));
    }

    public void FadeOut(Text text, float time)
    {
        StartCoroutine(FadeOutRoutine(text, time));
    }

    private IEnumerator FadeInRoutine(Text text, float time)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        while (text.color.a < 1f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }

    private IEnumerator FadeOutRoutine(Text text, float time)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        while (text.color.a > 0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}

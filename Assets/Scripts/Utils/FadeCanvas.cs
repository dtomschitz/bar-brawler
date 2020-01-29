using System.Collections;
using UnityEngine;

namespace Utils
{
    public class FadeCanvasGroup : MonoBehaviour
    {
        public void FadeIn(CanvasGroup canvas, float time = 1.5f)
        {
            StartCoroutine(FadeInRoutine(canvas, time));
        }

        public void FadeOut(CanvasGroup canvas, float time = 1.5f)
        {
            StartCoroutine(FadeOutRoutine(canvas, time));
        }

        private IEnumerator FadeInRoutine(CanvasGroup canvas, float time)
        {
            canvas.alpha = 0f;
            while (canvas.alpha < 1f)
            {
                canvas.alpha += (Time.deltaTime / time);
                yield return null;
            }
        }

        private IEnumerator FadeOutRoutine(CanvasGroup canvas, float time)
        {
            canvas.alpha = 0f;
            while (canvas.alpha > 0f)
            {
                canvas.alpha -= (Time.deltaTime / time);
                yield return null;
            }
        }
    }

}
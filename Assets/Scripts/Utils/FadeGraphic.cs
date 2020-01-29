using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class FadeGraphic : MonoBehaviour
    {
        public void FadeIn(Graphic graphic, float time = 1.5f)
        {
            StartCoroutine(FadeInRoutine(graphic, time));
        }

        public void FadeOut(Graphic graphic, float time = 1.5f)
        {
            StartCoroutine(FadeOutRoutine(graphic, time));
        }

        private IEnumerator FadeInRoutine(Graphic graphic, float time)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, 0f);
            while (graphic.color.a < 1f)
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a + (Time.deltaTime / time));
                yield return null;
            }
        }

        private IEnumerator FadeOutRoutine(Graphic graphic, float time)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, 1f);
            while (graphic.color.a > 0f)
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a - (Time.deltaTime / time));
                yield return null;
            }
        }
    }

}
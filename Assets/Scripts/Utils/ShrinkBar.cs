using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class ShrinkBar : MonoBehaviour
    {
        public Image barImage;
        public Image shrinkBarImage;

        public float maxShrinkTimer = 0.6f;

        private float shrinkTimer;

        void Update()
        {
            shrinkTimer -= Time.deltaTime;
            if (shrinkTimer < 0)
            {
                if (barImage.fillAmount < shrinkBarImage.fillAmount)
                {
                    float shrinkSpeed = 1f;
                    shrinkBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
                }
            }
        }

        protected void AlignBars()
        {
            shrinkBarImage.fillAmount = barImage.fillAmount;
        }

        protected void ResetShrinkTimer()
        {
            shrinkTimer = maxShrinkTimer;
        }

        protected void SetBarFillAmount(float amount)
        {
            barImage.fillAmount = amount;
        }
    }
}
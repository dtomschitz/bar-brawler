using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBarImage;
    public PlayerCombat playerCombat;

    void Start()
    {
        if (!manaBarImage)
        {
            throw new NullReferenceException("Manabar image is not set!");
        }
    }

    void Update()
    {
        if (playerCombat) manaBarImage.fillAmount = playerCombat.NormalizedMana;
    }
}

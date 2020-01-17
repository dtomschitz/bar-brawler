using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBarImage;
    private PlayerCombat playerCombat;

    void Start()
    {
        playerCombat = Player.instance.combat;


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

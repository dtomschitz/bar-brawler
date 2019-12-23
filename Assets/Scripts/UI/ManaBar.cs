using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBarImage;
    private PlayerCombat playerCombat;

    void Start()
    {
        playerCombat = Player.instance.combat;
    }

    void Update()
    {
        manaBarImage.fillAmount = playerCombat.ManaNormalized;
    }
}

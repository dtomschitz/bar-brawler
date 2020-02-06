using System;
using UnityEngine;
using UnityEngine.UI;

public class MunitionInfo : MonoBehaviour
{
    public Text currentMunition;

    void Start()
    {
        Inventory inventory = Player.instance.inventory;
        if (inventory == null) throw new ArgumentNullException("The player inventory cannot be null!");

        inventory.OnMunitionUpdate += OnMunitionUpdate;
    }

    public void OnMunitionUpdate(int currentAmount)
    {
        currentMunition.text = currentAmount.ToString();
    }
}

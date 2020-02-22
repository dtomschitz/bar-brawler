using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>MunitionInfo</c> manages the visualisation of the players amount of
/// ammunition by subscribing to the <see cref="Inventory.OnMunitionUpdate"/> event.
/// </summary>
public class MunitionInfo : MonoBehaviour
{
    public Text currentMunition;

    void Start()
    {
        PlayerInventory inventory = Player.instance.inventory;
        if (inventory == null) throw new ArgumentNullException("The player inventory cannot be null!");

        inventory.OnMunitionUpdate += OnMunitionUpdate;
    }

    /// <summary>
    /// Gets called if the amount of ammunition gets updated in some way and updates
    /// the ui text.
    /// </summary>
    /// <param name="currentAmount">The new amount of ammunition</param>
    public void OnMunitionUpdate(int currentAmount)
    {
        currentMunition.text = currentAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barkeeper : Interactable
{
    #region Singelton

    public static Barkeeper instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public Shop shop;
    private HUDManager hud;

    public void Start()
    {
        hud = HUDManager.instance;
    }

    public override void Interact()
    {
        base.Interact();
        if (shop.IsOpen)
        {
            InteractCanceled();
        } else
        {
            OpenShop();
        }
    }

    public override void InteractCanceled()
    {
        base.InteractCanceled();
        CloseShop();
    }

    public void OpenShop()
    {
        shop.SetOpen(true);
        hud.DisplayHealthBar(false);
        hud.DisplayManaBar(false);
        hud.DisplayHotbar(false);
    }

    public void CloseShop()
    {
        shop.SetOpen(false);
        hud.DisplayHealthBar(true);
        hud.DisplayManaBar(true);
        hud.DisplayHotbar(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") InteractCanceled();
    }
}

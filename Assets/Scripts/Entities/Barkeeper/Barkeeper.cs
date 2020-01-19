using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class Barkeeper : Interactable
{
    #region Singelton

    public static Barkeeper instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public ItemShop shop;
    private HUDManager hud;
    private WaveSpawner waveSpawner;

    void Start()
    {
        hud = HUDManager.instance;
        waveSpawner = WaveSpawner.instance;
        waveSpawner.OnWaveStateUpdate += OnWaveUpdate;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") InteractCanceled();
    }

    public void OnWaveUpdate(WaveState state) 
    {
        if (state == WaveState.Spawning || state == WaveState.Running)
        {
            CloseShop();
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (shop.IsOpen)
        {
            CloseShop();
        }
        else
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
        //hud.DisplayHotbar(false);
        hud.waveInfo.DisplayOnlySkipText(true);
    }

    public void CloseShop()
    {
        shop.SetOpen(false);
        hud.DisplayHealthBar(true);
        hud.DisplayManaBar(true);
        //hud.DisplayHotbar(true);
        hud.waveInfo.DisplayAll(true);
    }
}

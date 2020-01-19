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

    public void OpenShop()
    {
        shop.IsOpen = true;
        hud.DisplayHealthBar(false);
        hud.DisplayManaBar(false);
        hud.waveInfo.DisplayOnlySkipText(true);

        Player.instance.controls.IsMovementEnabled = false;
    }

    public void CloseShop()
    {
        shop.IsOpen = false;
        hud.DisplayHealthBar(true);
        hud.DisplayManaBar(true);
        hud.waveInfo.DisplayAll(true);

        Player.instance.controls.IsMovementEnabled = true;
    }
}

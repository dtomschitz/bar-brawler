using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singelton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public Inventory inventory;
    public EquipmentManager equipment;
    public PlayerStats stats;
    public EntityCombat combat;
    public PlayerAnimator animator;
    public GameObject player;

    public int money = 0;

    private int selectedHotbarIndex = 0;
    private KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1, //Key 1
        KeyCode.Alpha2, //Key 2
        KeyCode.Alpha3, //Key 3
        KeyCode.Alpha4, //Key 4
        KeyCode.Alpha5, //Key 5
    };

    void Start()
    {
        stats = player.GetComponent<PlayerStats>();
        combat = player.GetComponent<EntityCombat>();
        animator = player.GetComponent<PlayerAnimator>();
        inventory = player.GetComponent<Inventory>();
        equipment = player.GetComponent<EquipmentManager>();
     
        stats.OnHealthIsZero += Die;

        HUDManager.instance.UpdateMoneyText(money);
    }

    /*void LateUpdate()
    {
        for (int i = 0; i < hotbarControls.Length; i++)
        {
            if (Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
                if (selectedHotbarIndex < inventory.items.Count)
                {
                    Item item = inventory.items[i];
                    if (item is Equippable) equipment.Equip(item as Equippable);
                } else
                {
                    equipment.Unequip();
                }
            }
        }
    }*/

    void Die()
    {
        //TODO: Playe Die 
    }

    public void AddMoney(int amount)
    {
        money += amount;
        HUDManager.instance.UpdateMoneyText(money);
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        HUDManager.instance.UpdateMoneyText(money);
    }

    public int GetSelectedHotbarIndex() {
        return selectedHotbarIndex;
    }
}
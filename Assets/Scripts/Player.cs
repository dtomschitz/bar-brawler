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

    public PlayerStats stats;
    public EntityCombat combat;
    public GameObject player;

    public int money;

    private EquipmentManager equipment;
    private Inventory inventory;
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
        equipment = EquipmentManager.instance;
        inventory = Inventory.instance;
        stats = player.GetComponent<PlayerStats>();
        combat = player.GetComponent<EntityCombat>();
        stats.OnHealthIsZero += Die;

        Debug.Log(equipment);
    }

    void LateUpdate()
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
    }

    void Die()
    {
        //TODO: Playe Die 
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }

    public int GetSelectedHotbarIndex() {
        return selectedHotbarIndex;
    }
}

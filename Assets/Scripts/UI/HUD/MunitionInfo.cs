using UnityEngine;
using UnityEngine.UI;

public class MunitionInfo : MonoBehaviour
{
    public Text currentMunition;
    public Inventory inventory;

    void Start()
    {
       // inventory = Player.instance.inventory;
        inventory.OnMunitionUpdate += OnMunitionUpdate;    
    }

    public void OnMunitionUpdate(int currentAmount)
    {
        currentMunition.text = currentAmount.ToString();
    }
}

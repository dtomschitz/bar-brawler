using UnityEngine;
using UnityEngine.UI;

public class MunitionInfo : MonoBehaviour
{
    public Text currentMunition;
    public Inventory inventory;

    void Start()
    {
        inventory.OnMunitionUpdate += OnMunitionUpdate;    
    }

    public void OnMunitionUpdate(int currentAmount)
    {
        Debug.Log(currentAmount);

        currentMunition.text = currentAmount.ToString();
    }
}

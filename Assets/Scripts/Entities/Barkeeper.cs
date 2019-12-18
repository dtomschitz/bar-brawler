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

    public override void Interact()
    {
        if (shop.IsOpen)
        {
            CloseShop();
        } else
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        shop.SetOpen(true);
    }

    public void CloseShop()
    {
        shop.SetOpen(false);
    }

    private void OnTriggerStay(Collider other)
    {
     
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("DAD");
          //  Interact();
        }
    }
}

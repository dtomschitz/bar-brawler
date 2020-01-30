using UnityEngine;

public class HelpInfo : MonoBehaviour
{
    public GameObject weaponHelp;
    public GameObject targetHelp;

    public void SetWeaponHelpActive(bool active)
    {
        weaponHelp.gameObject.SetActive(active);
    }

    public void SetTargetHelpActive(bool active)
    {
        targetHelp.gameObject.SetActive(active);
    }

    public void SetActive(bool active) => gameObject.SetActive(active);

}

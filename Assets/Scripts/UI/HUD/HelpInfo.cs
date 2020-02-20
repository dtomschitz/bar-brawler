using UnityEngine;

/// <summary>
/// Class <c>HelpInfo</c> is used to display prefabricated game objects which
/// will give the user some hints how to control the player, use certain items
/// and so on.
/// </summary>
public class HelpInfo : MonoBehaviour
{
    public GameObject weaponHelp;
    public GameObject targetHelp;

    /// <summary>
    /// Displays the prefab of the weapon help.
    /// </summary>
    /// <param name="active"></param>
    public void SetWeaponHelpActive(bool active)
    {
        weaponHelp.gameObject.SetActive(active);
    }

    /// <summary>
    /// Displays the prefab of the target acquistion help.
    /// </summary>
    /// <param name="active"></param>
    public void SetTargetHelpActive(bool active)
    {
        targetHelp.gameObject.SetActive(active);
    }

    public void SetActive(bool active) => gameObject.SetActive(active);

}

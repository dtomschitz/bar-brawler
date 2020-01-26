using UnityEngine;

public class HelpInfo : MonoBehaviour
{
    public GameObject currentHelp;

    public void UpdateHelp(GameObject newHelp)
    {
        GameObject copy = Instantiate(newHelp, transform, false);

        Destroy(currentHelp);
        currentHelp = copy;
    }

    public void SetActive(bool active) => gameObject.SetActive(active);

}

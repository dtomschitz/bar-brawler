using UnityEngine;

public class HelpInfo : MonoBehaviour
{
    public GameObject currentHelp;

    public void UpdateHelp(GameObject newHelp)
    {
        Destroy(currentHelp);

        if (newHelp != null)
        {
            GameObject copy = Instantiate(newHelp, transform, false);
            currentHelp = copy;
        }
    }

    public void SetActive(bool active) => gameObject.SetActive(active);

}

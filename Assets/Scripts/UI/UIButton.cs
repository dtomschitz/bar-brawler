using UnityEngine.UI;

public class UIButton : Button
{
    protected override void Start()
    {
        onClick.AddListener(() => AudioManager.instance.PlaySound(Sound.ButtonClick));
    }
}

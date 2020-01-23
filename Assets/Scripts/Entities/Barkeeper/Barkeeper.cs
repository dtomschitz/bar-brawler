using Shop;

public class Barkeeper : Interactable
{
    #region Singelton

    public static Barkeeper instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public ItemShop shop;
    private UIManager uiManager;
    private WaveSpawner waveSpawner;

    void Start()
    {
        uiManager = UIManager.instance;
        waveSpawner = WaveSpawner.instance;
        waveSpawner.OnWaveStateUpdate += OnWaveUpdate;
    }

    public void OnWaveUpdate(WaveState state, int rounds) 
    {
        if (WaveSpawner.instance.IsWaveRunning)
        {
            if (shop.IsOpen) CloseShop();
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (!shop.IsOpen)
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        GameState.instance.SetState(State.IN_SHOP);
        shop.IsOpen = true;
        Player.instance.controls.IsMovementEnabled = false;
    }

    public void CloseShop()
    {
        shop.IsOpen = false;
        GameState.instance.SetState(State.INGAME);
        Player.instance.controls.IsMovementEnabled = true;
    }
}

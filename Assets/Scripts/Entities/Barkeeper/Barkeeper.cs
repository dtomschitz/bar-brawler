using UnityEngine;
using Shop;
using static UnityEngine.InputSystem.InputAction;

public class Barkeeper : MonoBehaviour
{
    #region Singelton

    public static Barkeeper instance;
    private PlayerInputActions inputActions;
    
    void Awake()
    {
        instance = this;

        inputActions = new PlayerInputActions();
        inputActions.UI.Select.performed += Select;
        inputActions.UI.Close.performed += Close;
    }

    #endregion;

    public ItemShop shop;
    private WaveSpawner waveSpawner;

    void Start()
    {
        waveSpawner = WaveSpawner.instance;
        waveSpawner.OnWaveStateUpdate += OnWaveUpdate;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnWaveUpdate(WaveState state, int rounds) 
    {
        if (WaveSpawner.instance.IsWaveRunning)
        {
            if (shop.IsOpen) CloseShop();

            inputActions.Disable();
        } else
        {
            inputActions.Enable();
        }
    }

    public void Select(CallbackContext ctx)
    {
        OpenShop();
    }

    public void Close(CallbackContext ctx)
    {
        CloseShop();
    }


    public void OpenShop()
    {
        if (shop.IsOpen) return;

        GameState.instance.SetState(State.IN_SHOP);
        shop.IsOpen = true;
    }

    public void CloseShop()
    {
        if (!shop.IsOpen) return;

        shop.IsOpen = false;
        GameState.instance.SetState(State.INGAME);
    }
}

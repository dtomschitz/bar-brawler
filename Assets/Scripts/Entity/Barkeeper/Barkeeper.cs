using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

using Shop;
using Wave;

/// <summary>
/// 
/// </summary>
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

    public Shop.Shop shop;
    public Animator animatior;
    private WaveSpawner waveSpawner;

    public bool isPlayerInReach = false;

    void Start()
    {
        waveSpawner = WaveSpawner.instance;
        waveSpawner.OnWaveStateUpdate += OnWaveStateUpdate;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    /// <summary>
    /// Gets triggerd if the player enters the interaction zone of the barkeeper and will update the
    /// isPlayerInReach parameter so the player can open the shop.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInReach = true;
        }
    }

    /// <summary>
    /// Gets triggerd if the player exits the interaction zone of the barkeeper and will update the
    /// isPlayerInReach parameter so the player can not open the shop anymore.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInReach = false;
            CloseShop();
        }
    }

    /// <summary>
    /// Gets called if the <see cref="WaveSpawner.OnWaveStateUpdate"/> event gets fired and will close or open the shop
    /// </summary>
    public void OnWaveStateUpdate(WaveState state, int rounds) 
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

    /// <summary>
    /// Gets triggerd if the user pressed the A-Button while he is in the interaction zone and the game state is not set to <see cref="GameStateType.GamePaused"/> or <see cref="GameStateType.GameOver"/>
    /// </summary>
    /// <param name="ctx"></param>
    public void Select(CallbackContext ctx)
    {
        if (isPlayerInReach && GameState.instance.State != GameStateType.GamePaused && GameState.instance.State != GameStateType.GameOver)
        {
            OpenShop();
        }
    }

    public void Close(CallbackContext ctx)
    {
        CloseShop();
    }

    public void OpenShop()
    {
        if (shop.IsOpen) return;
        GameState.instance.SetState(GameStateType.InShop);
        shop.IsOpen = true;
    }

    public void CloseShop()
    {
        if (!shop.IsOpen) return;

        shop.IsOpen = false;
        GameState.instance.SetState(GameStateType.InGame);
    }
}

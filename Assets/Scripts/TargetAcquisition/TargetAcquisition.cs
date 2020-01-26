using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class TargetAcquisition : MonoBehaviour
{
    #region Singelton

    public static TargetAcquisition instance;
    public PlayerInputActions inputActions;

    void Awake()
    {
        instance = this;
        inputActions = new PlayerInputActions();
        inputActions.Crosshair.ToggleCrosshair.performed += ToggleTargetAcquisition;
        inputActions.Crosshair.SelectLast.performed += SelectLast;
        inputActions.Crosshair.SelectNext.performed += SelectNext;
        inputActions.Crosshair.Unselect.performed += Unselect;
    }

    #endregion;

    private Enemy currentEnemey;
    private Enemy[] enemies;
    private int currentIndex;

    private readonly int interval = 2;
    private float nextTime = 0;

    public bool IsEnabled { get; set; } = false;

    void Update()
    {
        if (IsEnabled)
        {
            if (Time.time >= nextTime)
            {
                enemies = GetEnemies();
                nextTime += interval;
            }
        }
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    public void ToggleTargetAcquisition(CallbackContext context) => Toggle();
    public void SelectLast(CallbackContext context) => SelectLastEnemy();
    public void SelectNext(CallbackContext context) => SelectNextEnemy();
    public void Unselect(CallbackContext context) => UnselectCurrentEnemy();

    public void Toggle()
    {
        IsEnabled = !IsEnabled;

        if (IsEnabled)
        {
            Time.timeScale = 0.2f;
        }
    }

    public void SelectLastEnemy()
    {
        if (currentEnemey == null && enemies.Length != 0)
        {
            SelectEnemey(currentIndex - 1);
            return;
        }
    }

    public void SelectNextEnemy()
    {
        if (currentEnemey == null && enemies.Length != 0)
        {
            SelectEnemey(currentIndex + 1);
            return;
        }
    }

    public void UnselectCurrentEnemy()
    {
        if (currentEnemey != null)
        {
            currentEnemey.SetCrosshairActive(false);
        }
    }

    public void SelectEnemey(int nextIndex)
    {
        if (InBounds(nextIndex, enemies))
        {
            SetCurrentEnemy(enemies[nextIndex]);
            currentIndex = nextIndex;
        }
    }

    private void SetCurrentEnemy(Enemy enemy)
    {
        UnselectCurrentEnemy();

        currentEnemey = enemy;
        currentEnemey.SetCrosshairActive(true);
    }

    private Enemy[] GetEnemies() => FindObjectsOfType<Enemy>();

    private bool InBounds(int index, Enemy[] enemies)
    {
        return (index >= 0) && (index < enemies.Length);
    }
}

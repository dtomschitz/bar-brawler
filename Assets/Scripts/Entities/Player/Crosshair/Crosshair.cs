using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Crosshair : MonoBehaviour
{
    public PlayerInputActions inputActions;

    private Enemy currentEnemey;
    private Enemy[] enemies;
    private int currentIndex;

    private readonly int interval = 2;
    private float nextTime = 0;

    private bool isEnabled = false;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Crosshair.ToggleCrosshair.performed += ToggleCrosshair;
        inputActions.Crosshair.SelectLast.performed += SelectLast;
        inputActions.Crosshair.SelectNext.performed += SelectNext;
        inputActions.Crosshair.Unselect.performed += Unselect;
    }

    void Update()
    {
        if (isEnabled)
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

    public void ToggleCrosshair(CallbackContext context) => ToggleCrosshair();
    public void SelectLast(CallbackContext context) => ToggleCrosshair();
    public void SelectNext(CallbackContext context) => SelectNextEnemy();
    public void Unselect(CallbackContext context) => ToggleCrosshair();

    public void ToggleCrosshair()
    {
        isEnabled = !isEnabled;
    }

    public void SelectNextEnemy()
    {
        if (currentEnemey == null && enemies.Length != 0)
        {
            SelectEnemey(0);
            return;
        }
    }

    private void SelectEnemey(int index)
    {
        if (InBounds(index, enemies))
        {
            SetCurrentEnemy(enemies[0]);
            currentIndex = 0;
        }
    }

    private void SetCurrentEnemy(Enemy enemy)
    {
        currentEnemey = enemy;
    }

    private Enemy[] GetEnemies()
    {
        return FindObjectsOfType<Enemy>();
    }

    private bool InBounds(int index, Enemy[] enemies)
    {
        return (index >= 0) && (index < enemies.Length);
    }
}

using System;
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

    private float minDistance = Mathf.Infinity;

    public bool IsEnabled { get; set; } = false;

    void Update()
    {
        if (IsEnabled)
        {
            if (Time.time >= nextTime)
            {
                enemies = UpdateEnemies();
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

    public void SelectLast(CallbackContext context)
    {
        if (IsEnabled) SelectLastEnemy();
    }

    public void SelectNext(CallbackContext context)
    {
        if (IsEnabled) SelectNextEnemy();
    }

    public void Unselect(CallbackContext context)
    {
        if (IsEnabled) UnselectCurrentEnemy();
    }

    public void Toggle()
    {
        if (!GameState.instance.IsInGame) return;

        IsEnabled = !IsEnabled;
        Time.timeScale = IsEnabled ? 0.2f : 1.0f;
        GameState.instance.SetState(IsEnabled ? State.TARGET_ACQUISITION : State.INGAME);

        Debug.Log("Target Acquisition: " + IsEnabled + "(timeScale: " + Time.timeScale + ")");

        if (IsEnabled)
        {
            UpdateEnemies();
            if (currentEnemey == null)
            {
                Enemy enemy = FindClosestEnemy();
                if (enemy != null) SelectEnemy(enemy);
            }
        }
    }

    public void SelectLastEnemy()
    {
        if (enemies.Length != 0)
        {
            SelectEnemy(currentIndex - 1);
            return;
        }
    }

    public void SelectNextEnemy()
    {
        if (enemies.Length != 0)
        {
            SelectEnemy(currentIndex + 1);
            return;
        }
    }

    public Enemy FindClosestEnemy()
    {
        Enemy enemy = null;
        Vector3 playerPositon = Player.instance.gameObject.transform.position;
        for (int i = 0; i < enemies.Length; i++) 
        {
            float distance = Vector3.Distance(enemies[i].transform.position, playerPositon);
            if (distance < minDistance)
            {
                enemy = enemies[i];
            }
        }
        return enemy;
    }

    public void UnselectCurrentEnemy()
    {
        if (currentEnemey != null)
        {
            currentEnemey.SetCrosshairActive(false);
        }
    }

    public void SelectEnemy(Enemy enemy)
    {
        SetCurrentEnemy(enemy);
    }

    private void SelectEnemy(int nextIndex)
    {
        if (InBounds(nextIndex, enemies))
        {
            SetCurrentEnemy(enemies[nextIndex]);
           // currentIndex = nextIndex;
        }
    }

    private void SetCurrentEnemy(Enemy enemy)
    {
        UnselectCurrentEnemy();

        currentEnemey = enemy;
        currentIndex = Array.IndexOf(enemies, enemy);
        currentEnemey.SetCrosshairActive(true);
    }

    private Enemy[] UpdateEnemies() => enemies = FindObjectsOfType<Enemy>();

    private bool InBounds(int index, Enemy[] enemies)
    {
        return (index >= 0) && (index < enemies.Length);
    }
}

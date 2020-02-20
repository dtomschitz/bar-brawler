using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using Utils;

/// <summary>
/// Class <c>TargetAcquisition</c> is used to provide an slow moition mode
/// ingame in order to help the player to select an specific enemy. This should
/// improve the attacks of the player and make it easier to hit an enemy with
/// the revolver since the player will turn towards an enemy after selection.
/// </summary>
public class TargetAcquisition : MonoBehaviour
{
    #region Singelton

    public static TargetAcquisition instance;
    public PlayerInputActions inputActions;

    /// <summary>
    /// Subscribes to the set <see cref="PlayerInputActions"/> controlls. 
    /// </summary>
    void Awake()
    {
        instance = this;
        inputActions = new PlayerInputActions();
        inputActions.Crosshair.ToggleCrosshair.performed += ToggleTargetAcquisition;
        inputActions.Crosshair.SelectLast.performed += SelectLast;
        inputActions.Crosshair.SelectNext.performed += SelectNext;
        inputActions.Crosshair.SelectNearest.performed += SelectNearest;
        inputActions.Crosshair.Unselect.performed += Unselect;
    }

    #endregion;

    public Enemy CurrentEnemy { get; protected set; }
    private List<Enemy> enemies = new List<Enemy>();
    private int currentIndex;

    private readonly float minDistance = Mathf.Infinity;

    public bool IsEnabled { get; set; } = false;

    void Start()
    {
        FunctionPeriodic.Create(() =>
        {
            UpdateEnemies();
            if (enemies.Count == 0 && IsEnabled)
            {
                Toggle();
            }

        }, 1f);
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
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should toggle
    /// the target acquisition mode.
    /// </summary>
    public void ToggleTargetAcquisition(CallbackContext context)
    {
        Toggle();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should select
    /// the nearest enemy while he is in the target acquisition mode.
    /// </summary>
    public void SelectNearest(CallbackContext context)
    {
        if (IsEnabled) SelectClosestEnemy();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should select
    /// the last enemy while he is in the target acquisition mode.
    /// </summary>
    public void SelectLast(CallbackContext context)
    {
        if (IsEnabled) SelectLastEnemy();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should select
    /// the next enemy while he is in the target acquisition mode.
    /// </summary>
    public void SelectNext(CallbackContext context)
    {
        if (IsEnabled) SelectNextEnemy();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should unselect
    /// the current selected enemy while he is in the target acquisition mode.
    /// </summary>
    public void Unselect(CallbackContext context)
    {
        if (IsEnabled) UnselectCurrentEnemy();
    }

    /// <summary>
    /// This method enables or disables the target acquisition mode but only if
    /// the <see cref="GameState"/> is set to <see cref="GameStateType.InGame"/>.
    /// It will then update the <see cref="Time.timeScale"/> and the <see cref="GameState"/>
    /// accordingly. If the target acquistion mode got enabled this method will
    /// also select the nearest enemy.
    /// </summary>
    public void Toggle()
    {
        if (!GameState.instance.IsInGame) return;

        IsEnabled = !IsEnabled;
        Time.timeScale = IsEnabled ? 0.2f : 1.0f;
        GameState.instance.SetState(IsEnabled ? GameStateType.TargetAcquisition : GameStateType.InGame);

        if (IsEnabled)
        {
            if (CurrentEnemy == null)
            {
                SelectClosestEnemy();
            }
        }
    }

    /// <summary>
    /// Selects the last enemy.
    /// </summary>
    public void SelectLastEnemy()
    {
        if (enemies.Count != 0)
        {
            SelectEnemy(currentIndex - 1);
            return;
        }
    }

    /// <summary>
    /// Selects the next enemy.
    /// </summary>
    public void SelectNextEnemy()
    {
        if (enemies.Count != 0)
        {
            SelectEnemy(currentIndex + 1);
            return;
        }
    }

    /// <summary>
    /// Selects the closest enemy to the player.
    /// </summary>
    public void SelectClosestEnemy()
    {
        SelectEnemy(FindClosestEnemy());
    }

    /// <summary>
    /// Unselects the current selected enemy. If <paramref name="autoSelect"/>
    /// is true the next closest enemy will get selected.
    /// </summary>
    /// <param name="autoSelect">Should be true if a new enemy should be selected automatically.</param>
    public void UnselectCurrentEnemy(bool autoSelect = false)
    {
        if (CurrentEnemy != null)
        {
            SelectEnemy(null);
            if (autoSelect) SelectClosestEnemy();
        }
    }

    /// <summary>
    /// Selects the given enemy.
    /// </summary>
    /// <param name="enemy">The enemy which should get selected</param>
    public void SelectEnemy(Enemy enemy)
    {
        SetCurrentEnemy(enemy);
    }

    /// <summary>
    /// Selects an enemy from the <see cref="enemies"/> list by the given index.
    /// </summary>
    /// <param name="nextIndex">The index of the enemy in the enemies list.</param>
    private void SelectEnemy(int nextIndex)
    {
        if (List.InBounds(nextIndex, enemies.Count))
        {
            SetCurrentEnemy(enemies[nextIndex]);
        }
    }

    /// <summary>
    /// This method tries to find the closest enemy to the player. This happens
    /// by calculating the distance between the player and each alive enemy.
    /// </summary>
    /// <returns>The closest enemy if there is one; otherwise null.</returns>
    private Enemy FindClosestEnemy()
    {
        Enemy enemy = null;
        UpdateEnemies();
        if (enemies != null && enemies.Count != 0)
        {
            Vector3 playerPositon = Player.instance.gameObject.transform.position;
            for (int i = 0; i < enemies.Count; i++)
            {
                float distance = Vector3.Distance(enemies[i].transform.position, playerPositon);
                if (distance < minDistance)
                {
                    enemy = enemies[i];
                }
            }
        }
        return enemy;
    }

    /// <summary>
    /// Sets the current enemy, disables the crosshair for the old and enables
    /// it for the new one.
    /// </summary>
    /// <param name="enemy">The new selected enemy.</param>
    private void SetCurrentEnemy(Enemy enemy)
    {
        if (CurrentEnemy != null)
        {
            CurrentEnemy.SetCrosshairActive(false);
        }

        currentIndex = enemy == null ? -1 : enemies.IndexOf(enemy);
        CurrentEnemy = enemy;

        if (CurrentEnemy != null)
        {
            CurrentEnemy.SetCrosshairActive(true);
        }
    }

    /// <summary>
    /// This method will update the <see cref="enemies"/> list to provide this
    /// class an information about how many enemies are currently alive.
    /// </summary>
    private void UpdateEnemies()
    {
        enemies.Clear();
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            if (enemy.stats.IsDead) continue;
            enemies.Add(enemy);
        }
    }
}

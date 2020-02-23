using UnityEngine;

/// <summary>
/// Class <c>GameOver</c> is used to open the main menu. From here the user
/// can either quit the game or start a new round if he wants to.
/// </summary>
public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainScene";
    public SceneFader sceneFader;

    /// <summary>
    /// Fades into the main level.
    /// </summary>
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }   
}

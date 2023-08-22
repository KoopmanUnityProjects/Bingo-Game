using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    /// <summary>
    /// Canvas for the start screen
    /// </summary>
    [SerializeField]
    Canvas startScreenCanvas;

    /// <summary>
    /// Canvas for the GamePlay Screen
    /// </summary>
    [SerializeField]
    Canvas gamePlayCanvas;

    // Start button
    [SerializeField]
    Button startButton;


    /// <summary>
    /// Called when start button is clicked. This will move player to
    /// game play screen.
    /// </summary>
    public void StartGame()
    {
        startScreenCanvas.enabled = false;
        gamePlayCanvas.enabled = true;
        startButton.interactable = false;
        GameManager.Instance.StartGame();
    }

    /// <summary>
    /// Returns back to start screen.
    /// </summary>
    public void LoadStartScreen()
    {
        startScreenCanvas.enabled = true;
        gamePlayCanvas.enabled = false;
        startButton.interactable = true;

    }
}

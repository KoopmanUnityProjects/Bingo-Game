using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // True if game is paused
    bool pauseEnabled = false;

    // Sprite for Play Button.
    [SerializeField]
    Sprite PlayButtonImage;

    // Sprite for pause button.
    [SerializeField]
    Sprite PauseButtonImage;

    // Image for play or pause sprites
    [SerializeField]
    Image playOrPauseButtonImage;

    /// <summary>
    /// Pauses or unpauses game when clicked.
    /// </summary>
    public void PlayOrPauseGameClicked()
    {
        pauseEnabled = !pauseEnabled;
        if (pauseEnabled)
        {
            playOrPauseButtonImage.sprite = PlayButtonImage;
            GameManager.Instance.PauseGame();
        }
        else
        {

            playOrPauseButtonImage.sprite = PauseButtonImage;
            GameManager.Instance.UnpauseGame();
        }
    }
}

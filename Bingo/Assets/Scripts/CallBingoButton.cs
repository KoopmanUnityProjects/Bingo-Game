using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBingoButton : MonoBehaviour
{
    /// <summary>
    /// Called when user clicks the Call Bingo button.
    /// </summary>
    public void CallBingoButtonClicked()
    {
        GameManager.Instance.CheckForPlayerBingo();
    }
}

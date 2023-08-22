using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalledNumberBoard : MonoBehaviour
{
    // list of all the cells of called numbers.
    public List<TMP_Text> calledNumbers = new List<TMP_Text>();

    /// <summary>
    /// colors for called numbers and uncalled numbers.
    /// </summary>
    Color calledNumberColor = new Color(1f, 1f, 1f, 1f);
    Color uncalledNumberColor = new Color(0.1f, 0.1f, 0.1f, 0.1f);

    /// <summary>
    /// Clears all called numbers on the board.
    /// </summary>
    public void ClearCalledNumberBoard()
    {
        foreach (TMP_Text calledNumber in calledNumbers)
        {
            calledNumber.color = uncalledNumberColor;
        }
    }

    /// <summary>
    /// Marks the number called on the called number board.
    /// </summary>
    /// <param name="number"></param>
    public void markNumber(int number)
    {
        if (number <= 0 || number > calledNumbers.Count)
            return;

        calledNumbers[number - 1].color = calledNumberColor;
    }
}

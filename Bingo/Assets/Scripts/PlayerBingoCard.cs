using System.Collections.Generic;
using UnityEngine;

public class PlayerBingoCard : MonoBehaviour
{
    // The cells for the computers bingo card
    public List<GameObject> playerCells = new List<GameObject>();

    // List of numbers on the computers bingo card.
    List<int> bingoCardNumbers = new List<int>();

    /// <summary>
    /// Clears all bingo numbers, dobs, and sets up new numbers on card. 
    /// </summary>
    public void SetupBingoCard()
    {
        bingoCardNumbers.Clear();

        foreach (GameObject cell in playerCells)
        {
            cell.GetComponent<BingoCell>().clearCell();
        }

        // B row
        while (bingoCardNumbers.Count < 5)
        {
            int testNumber = Random.Range(1, 16);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // I row
        while (bingoCardNumbers.Count < 10)
        {
            int testNumber = Random.Range(16, 31);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // N row
        while (bingoCardNumbers.Count < 15)
        {
            if (bingoCardNumbers.Count == 12)
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().MarkCellAsFree();
                bingoCardNumbers.Add(0);
                continue;
            }

            int testNumber = Random.Range(31, 46);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // G row
        while (bingoCardNumbers.Count < 20)
        {
            int testNumber = Random.Range(46, 61);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // O row
        while (bingoCardNumbers.Count < 25)
        {
            int testNumber = Random.Range(61, 75);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                playerCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }
    }

    /// <summary>
    /// Gets the numbers on the bingo card.
    /// </summary>
    /// <returns>list of numbers on bingo card.</returns>
    public List<int> GetNumbers()
    {
        return bingoCardNumbers;
    }
}

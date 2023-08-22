using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompBingoCard : MonoBehaviour
{
    // The cells for the computers bingo card
    public List<GameObject> compCells = new List<GameObject>();

    // List of numbers on the computers bingo card.
    List<int> bingoCardNumbers = new List<int>();

    // Name currenlty set in inspector.
    [SerializeField]
    string computerName;

    /// <summary>
    /// Clears all bingo numbers, dobs, and sets up new numbers on card. 
    /// </summary>
    public void SetupBingoCard()
    {
        bingoCardNumbers.Clear();

        foreach (GameObject cell in compCells)
        {
            cell.GetComponent<BingoCell>().clearCell();
        }

        // B row
        while (bingoCardNumbers.Count < 5)
        {
            int testNumber = Random.Range(1, 16);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // I row
        while (bingoCardNumbers.Count < 10)
        {
            int testNumber = Random.Range(16, 31);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // N row
        while (bingoCardNumbers.Count < 15)
        {
            // free space.
            if (bingoCardNumbers.Count == 12)
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().MarkCellAsFree();
                bingoCardNumbers.Add(0);
                continue;
            }

            int testNumber = Random.Range(31, 46);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // G row
        while (bingoCardNumbers.Count < 20)
        {
            int testNumber = Random.Range(46, 61);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }

        // O row
        while (bingoCardNumbers.Count < 25)
        {
            int testNumber = Random.Range(61, 75);
            if (!bingoCardNumbers.Contains(testNumber))
            {
                compCells[bingoCardNumbers.Count].GetComponent<BingoCell>().SetNumber(testNumber);
                bingoCardNumbers.Add(testNumber);
            }
        }
    }

    /// <summary>
    /// Checks to see if computer has specific number.
    /// </summary>
    /// <param name="number">The number being called.</param>
    public void CheckForNumber(int number)
    {
        if (bingoCardNumbers.Contains(number))
        {
            int indexofNumber = bingoCardNumbers.IndexOf(number);
            compCells[indexofNumber].GetComponent<BingoCell>().MarkOrUnmarkCell();
        }
    }

    /// <summary>
    /// Mark All free s paces (in case I add varient that has other free spaces I'm setting free space to number 0 for now)
    /// </summary>
    public void MarkFreeSpace()
    {
        var freeSpaces = bingoCardNumbers.Where(x => x == 0);
        foreach (int number in freeSpaces)
        {
            int indexofNumber = bingoCardNumbers.IndexOf(number);
            compCells[indexofNumber].GetComponent<BingoCell>().MarkOrUnmarkCell();
        }
    }

    /// <summary>
    /// Getter for list of numbers the computers bingo ticket has.
    /// </summary>
    /// <returns>returns numbers on computers bingo card</returns>
    public List<int> GetNumbers()
    {
        return bingoCardNumbers;
    }

    /// <summary>
    /// Getter for computers name.
    /// </summary>
    /// <returns>computers name./returns>
    public string GetName()
    {
        return computerName;
    }
}

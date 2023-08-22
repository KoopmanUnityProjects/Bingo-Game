using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BingoCell : MonoBehaviour
{
    // Number text field.
    [SerializeField]
    TMP_Text numberTextField;

    // Image of the bingo dob
    [SerializeField]
    Image Splotch;

    // bingo number stored in cell
    int cellNumber;

    /// <summary>
    /// clears cell of bingo number, text, and splotch.
    /// </summary>
    public void clearCell()
    {
        numberTextField.text = "";
        cellNumber = -1;
        Splotch.enabled = false;
    }

    /// <summary>
    /// Marks cell if unmarked. otherwise unmarks the cell
    /// </summary>
    public void MarkOrUnmarkCell()
    {
        if (!GameManager.Instance.GetGameOver())
        {
            Splotch.enabled = !Splotch.enabled;
        }
    }

    /// <summary>
    /// Sets the bingo number of this cell
    /// </summary>
    /// <param name="number">number to set cell to.</param>
    public void SetNumber(int number)
    {
        cellNumber = number;
        numberTextField.text = number.ToString();
    }

    /// <summary>
    /// Marks cell as a free space.
    /// </summary>
    public void MarkCellAsFree()
    {
        numberTextField.text = "Free";
        cellNumber = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager instance for singleton
    private static GameManager instance;

    // Object scripts for permanent objects
    public StartScreen startScreen;
    public PlayerBingoCard playerCard;
    public CompBingoCard compCard1;
    public CompBingoCard compCard2;
    public CalledNumberBoard calledNumberBoard;
    public TMP_Text CurrentNumber;
    [SerializeField]
    GameObject winnerTextObject;

    // difficulty for computer.
    public int difficulty;

    // Speed setting 
    public int speed;

    // callspeed (currently set in inspector)
    public float CallSpeed = 5.0f;


    // List of all numbers called.
    List<int> calledNumbers = new List<int>();

    // is the game currenlty over?
    bool gameOver = false;

    // is the game currenlty paused?
    bool gamePaused = false;

    /// <summary>
    /// Set up singleton for GameManager
    /// </summary>
    public static GameManager Instance
    {
        get => instance;
        private set
        {
            if (instance == null)
            {
                instance = value;
            }
            else if (instance != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    /// <summary>
    /// Initialize singleton to this GameManager and load start screen.
    /// </summary>
    private void Awake()
    {
        Instance = this;
        startScreen.LoadStartScreen();
    }

    /// <summary>
    /// Clear board, Set up Bingo cards, called numbers and start a new game of Bingo.
    /// </summary>
    public void StartGame()
    {
        gameOver = false;
        calledNumbers.Clear();
        calledNumbers.Add(0);
        ClearDisplayedNumber();
        playerCard.SetupBingoCard();
        compCard1.SetupBingoCard();
        compCard2.SetupBingoCard();
        calledNumberBoard.ClearCalledNumberBoard();
        StartCoroutine("PlayBingo");
        winnerTextObject.SetActive(false);
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        gamePaused = true;
    }

    /// <summary>
    /// Unpauses the game.
    /// </summary>
    public void UnpauseGame()
    {
        gamePaused = false;
    }


    /// <summary>
    /// Check if there is a valid bingo
    /// </summary>
    /// <param name="BingoNumbers"></param>
    /// <returns>currenlty just returns a bool indicating if there is a bingo. However may be updated later to indicate which line, or cells has the bingo</returns>
    public bool CheckIfCardHasBingo(List<int> BingoNumbers)
    {
        bool validBingo = false;

        // this is good for line bingo, but can be extended for others.
        // this is also broken into multiple if statements in case I want to at any point decifer which bingo I got I can then return an int instead of a bool telling which "line" had a bingo
        // vertical Line checka
        if (IsValidLine(BingoNumbers[0], BingoNumbers[1], BingoNumbers[2], BingoNumbers[3], BingoNumbers[4]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[5], BingoNumbers[6], BingoNumbers[7], BingoNumbers[8], BingoNumbers[9]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[10], BingoNumbers[11], BingoNumbers[12], BingoNumbers[13], BingoNumbers[14]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[15], BingoNumbers[16], BingoNumbers[17], BingoNumbers[18], BingoNumbers[19]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[20], BingoNumbers[21], BingoNumbers[22], BingoNumbers[23], BingoNumbers[24]))
        {
            validBingo = true;
        }
                                                                                                
        // horizontal Line checka                                                                              
        if (IsValidLine(BingoNumbers[0], BingoNumbers[5], BingoNumbers[10], BingoNumbers[15], BingoNumbers[20]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[1], BingoNumbers[6], BingoNumbers[11], BingoNumbers[16], BingoNumbers[21]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[2], BingoNumbers[7], BingoNumbers[12], BingoNumbers[17], BingoNumbers[22]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[3], BingoNumbers[8], BingoNumbers[13], BingoNumbers[18], BingoNumbers[23]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[4], BingoNumbers[9], BingoNumbers[14], BingoNumbers[19], BingoNumbers[24]))
        {
            validBingo = true;
        }
                                                                                                            
        // diagonal line checks
        if (IsValidLine(BingoNumbers[0], BingoNumbers[6], BingoNumbers[12], BingoNumbers[18], BingoNumbers[24]))
        {
            validBingo = true;
        }

        if (IsValidLine(BingoNumbers[4], BingoNumbers[8], BingoNumbers[12], BingoNumbers[16], BingoNumbers[20]))         
        {
            validBingo = true;
        }


        return validBingo;
    }

    /// <summary>
    /// Checks if the players card has a bingo. This function is called
    /// when a player clicks the Call Bingo button.
    /// </summary>
    public void CheckForPlayerBingo()
    {
        // Get the numbers from the players card.
        List<int> playerNumbers = playerCard.GetNumbers();

        // check if player has a bingo
        if (CheckIfCardHasBingo(playerNumbers))
        {
            winnerTextObject.GetComponentInChildren<TMP_Text>().text = "Player Wins!!";
            winnerTextObject.SetActive(true);
            StartCoroutine("EndGame");

        }
        else
        {
            Debug.Log("Player clicked Call Bingo, but does not have a valid Bingo");
        }
    }

    public void CheckForComputerBingo(CompBingoCard bingoCard)
    {
        List<int> computerNumbers = bingoCard.GetNumbers();

        if (CheckIfCardHasBingo(computerNumbers))
        {
            winnerTextObject.GetComponentInChildren<TMP_Text>().text = bingoCard.GetName() + " Wins";
            winnerTextObject.SetActive(true);
            StartCoroutine("EndGame");

        }
    }

    /// <summary>
    /// Getter for gameOver. Used to tell cells if the game is still going
    /// and thus can be marked or unmarked.
    /// </summary>
    /// <returns></returns>
    public bool GetGameOver()
    {
        return gameOver;
    }

    /// <summary>
    /// Gets a random bingo number between 1 and 75 (standard bingo numbers)
    /// </summary>
    /// <returns>Random bingonNumber.</returns>
    int GetRandomNumber()
    {
        int number = Random.Range(1, 76);
        return number;
    }

    /// <summary>
    /// Gets the next uncalled bingo number and adds it to the called numberl ist.
    /// </summary>
    /// <returns>returns new number to call.</returns>
    int GetNextNumber()
    {
        int number = GetRandomNumber();
        while (calledNumbers.Contains(number))
        {
            number = GetRandomNumber();
        }

        calledNumbers.Add(number);
        string letter = SetBingerLetter(number);
        return number;
    }

    /// <summary>
    /// Gets the bingo letter for a n associated number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns>returns Bingo letter.</returns>
    string SetBingerLetter(int number)
    {
        string letter = "Unknown";

        if (number <= 0 || number > 75)
            letter = "Error";
        else if (number <= 15)
            letter = "B";
        else if (number <= 30)
            letter = "I";
        else if (number <= 45)
            letter = "N";
        else if (number <= 60)
            letter = "G";
        else if (number <= 75)
            letter = "O";

        return letter;
    }

    /// <summary>
    /// Displays the letter and being called.
    /// </summary>
    /// <param name="number">The Number being called</param>
    void DisplayNumber(int number)
    {
        CurrentNumber.text = SetBingerLetter(number) + "\n" + number;
        calledNumberBoard.markNumber(number);
    }

    /// <summary>
    /// Clear out the next number display.
    /// </summary>
    void ClearDisplayedNumber()
    {
        CurrentNumber.text = "";
    }

    /// <summary>
    /// Chceks specifically if there is a line bingo. If all 5 return true then there is a valid bingo
    /// </summary>
    /// <param name="spot1">First number to check</param>
    /// <param name="spot2">Second number to check</param>
    /// <param name="spot3">Third number to check</param>
    /// <param name="spot4">Fourth number to check</param>
    /// <param name="spot5">Fifth number to check</param>
    /// <returns></returns>
    bool IsValidLine(int spot1, int spot2, int spot3, int spot4, int spot5)
    {
        return (calledNumbers.Contains(spot1) && calledNumbers.Contains(spot2) && calledNumbers.Contains(spot3) && calledNumbers.Contains(spot4) && calledNumbers.Contains(spot5));
    }

    /// <summary>
    /// Coroutine for playing Bingo. This is used ot wait between the call
    /// of each bingo number to allow time for marking your own bingo card.
    /// </summary>
    /// <returns>Returns only used for delays.</returns>
    IEnumerator PlayBingo()
    {
        // 5 second delay before starting game.
        yield return new WaitForSeconds(5);
        compCard1.MarkFreeSpace();
        compCard2.MarkFreeSpace();

        // Set the speed at which numbers are called.
        float timeBetweenNumbers = 10 - CallSpeed;
        while (!gameOver && calledNumbers.Count <= 75)
        {
            yield return new WaitForSeconds(0.05f);

            // Only call next number if the game is not paused
            if (!gamePaused)
            {
                int number = GetNextNumber();
                DisplayNumber(number);

                // wait until its been long enough for next number to be called.
                float timeWaited = 0.0f;
                while (timeWaited < timeBetweenNumbers)
                {
                    yield return null;
                    timeWaited += Time.deltaTime;
                }

                if (!gameOver)
                {
                    // mark numbers and check for bingo on computer players.
                    compCard1.CheckForNumber(number);
                    compCard2.CheckForNumber(number);

                    CheckForComputerBingo(compCard1);
                    CheckForComputerBingo(compCard2);
                }
            }
        }
    }

    /// <summary>
    /// Coroutine used ot give a small delay before returning to start screen.
    /// </summary>
    /// <returns></returns>
    IEnumerator EndGame()
    {
        gameOver = true;
        yield return new WaitForSeconds(5.0f);

        startScreen.LoadStartScreen();
    }
}

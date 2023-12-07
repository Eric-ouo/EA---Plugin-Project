using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerUI;
    public static int timeRemaining = 120;

    void Start()
    {
        InvokeRepeating(nameof(CountDown), 1, 1);
    }

    private void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining--;
            UpdateTimerUI();
            return;
        }

        EndGame();
    }

    private void UpdateTimerUI()
    {
        string minutes = (timeRemaining / 60).ToString();
        string seconds = (timeRemaining % 60).ToString("00"); // leading zero for values less than 10

        timerUI.text = $"{minutes}:{seconds}";
    }

    private void EndGame()
    {
        print("Game Over! Your score is " + checkResult.score.ToString());
        CancelInvoke(); // stop all invoke repeating call
    }

    void Update()
    {
        // If there is a need to perform updates every frame, they should be placed here
    }
}
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerScore_text;
    [SerializeField] TextMeshProUGUI BotScore_text;
    [SerializeField] TextMeshProUGUI Win_text;

    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject InfoUI;

    [SerializeField] Rigidbody botRigidbody; 
    [SerializeField] Rigidbody playerRigidbody;

    [SerializeField] PlayerController playerController;
    [SerializeField] AIController aIController;

    public int playerScore = 0;
    public int botScore = 0;

    void Start()
    {
        UpdateScoreUI();
        WinUI.SetActive(false);
        playerController.enabled = false;
        aIController.enabled = false;
        ShowInfoUIForDuration(1.5f);
    }

    public void IncrementPlayerScore()
    {
        playerScore++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    public void IncrementBotScore()
    {
        botScore++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    public void ResetGame()
    {
        playerScore = 0;
        botScore = 0;
        UpdateScoreUI();
        WinUI.SetActive(false);
        Time.timeScale = 1f;

        playerController.enabled = false;
        aIController.enabled = false;
        ShowInfoUIForDuration(1.5f);
    }

    void UpdateScoreUI()
    {
        PlayerScore_text.text = playerScore.ToString();
        BotScore_text.text = botScore.ToString();
    }

    void CheckWinCondition()
    {
        if (playerScore >= 3)
        {
            WinUI.SetActive(true);
            Win_text.text = "You Win!";
            Time.timeScale = 0f;
        }
        else if (botScore >= 3)
        {
            WinUI.SetActive(true);
            Win_text.text = "Bot Wins!";
            Time.timeScale = 0f;
        }
    }

    void ShowInfoUIForDuration(float duration)
    {
        InfoUI.SetActive(true);
        Invoke("DisableInfoUI", duration);
    }

    void DisableInfoUI()
    {
        playerController.enabled = true;
        aIController.enabled = true;

        if (botRigidbody != null)
        {
            botRigidbody.isKinematic = false;
        }
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false;
        }

        InfoUI.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerLeftScore = 0;
    public int playerRightScore = 0;
    public int winPoints = 3;

    public KeyCode keyCodeReset = KeyCode.R;

    [Header("Transform Paddles")]
    public Transform playerLeftPaddle;
    public Transform playerRightPaddle;

    [Header("TextMesh Paddles")]
    public TextMeshProUGUI textPointLeftPlayer;
    public TextMeshProUGUI textPointRightPlayer;

    [Header("Ball Script")]
    public BallController ballController;

    [Header("End Game References")]
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public void Start()
    {
        ResetGame();
    }

    public void Update()
    {
        if (Input.GetKeyUp(keyCodeReset))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        //garante as posições dos players
        playerLeftPaddle.position = new Vector3(-7f, 0f, 0f);
        playerRightPaddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        playerLeftScore = 0;
        playerRightScore= 0;

        textPointLeftPlayer.text = playerLeftScore.ToString();
        textPointRightPlayer.text = playerRightScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayerLeft()
    {
        playerLeftScore++;
        textPointLeftPlayer.text = playerLeftScore.ToString();
        CheckWin();
    }

    public void ScorePlayerRight()
    {
        playerRightScore++;
        textPointRightPlayer.text = playerRightScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(playerLeftScore == winPoints || playerRightScore == winPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveControllerPong.Instance.GetName(playerLeftScore > playerRightScore);
        textEndGame.text = winner + " GANHOU!";

        if (playerLeftScore > SaveControllerPong.Instance.GetHighestPlayer1Score())
        {
            SaveControllerPong.Instance.SaveHighestPlayer1(playerLeftScore, SaveControllerPong.Instance.namePlayer);
        }

        if (playerLeftScore > SaveControllerPong.Instance.GetHighestPlayer2Score())
        {
            SaveControllerPong.Instance.SaveHighestPlayer2(playerRightScore, SaveControllerPong.Instance.nameEnemy);
        }

        SaveControllerPong.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 3f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}

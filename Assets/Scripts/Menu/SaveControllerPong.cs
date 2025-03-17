using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveControllerPong : MonoBehaviour
{

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    [Header("Names")]
    public string namePlayer = "Jogador 1";
    public string nameEnemy = "Jogador 2";

    private static SaveControllerPong _instance;

    private string saveWinnerKey = "SavedWinner";
    private string highestPlayer1Key = "HighestPlayer1";
    private string highestPlayer2Key = "HighestPlayer2";

    private string highestPlayer1KeyScore = "HighestPlayer1Score";
    private string highestPlayer2KeyScore = "HighestPlayer2Score";

    public static SaveControllerPong Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SaveControllerPong>();

                if(_instance == null)
                {
                    GameObject singleObject = new GameObject(typeof(SaveControllerPong).Name);
                    _instance = singleObject.AddComponent<SaveControllerPong>();
                }
            }
            return _instance;
        }
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void Reset()
    {
        namePlayer = "Jogador1";
        nameEnemy = "Jogador2";
        colorPlayer = Color.white;
        colorEnemy = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey, "");
    }

    public void SaveHighestPlayer1(int highestPlayer1Score, string highestPlayer1Name)
    {
        string highestPlayer1 = highestPlayer1Name + " | Pontos: " + highestPlayer1Score.ToString();
        PlayerPrefs.SetString(highestPlayer1Key, highestPlayer1);
        PlayerPrefs.SetInt(highestPlayer1KeyScore, highestPlayer1Score);
    }

    public int GetHighestPlayer1Score()
    {
        return PlayerPrefs.GetInt(highestPlayer1KeyScore, 0);
    }

    public string GetHighestPlayer1()
    {
        return PlayerPrefs.GetString(highestPlayer1Key, "");
    }


    public void SaveHighestPlayer2(int highestPlayer2Score, string highestPlayer2Name)
    {
        string highestPlayer2 = highestPlayer2Name + " | Pontos: " + highestPlayer2Score.ToString();
        PlayerPrefs.SetString(highestPlayer2Key, highestPlayer2);
        PlayerPrefs.SetInt(highestPlayer2KeyScore, highestPlayer2Score);
    }

    public int GetHighestPlayer2Score()
    {
        return PlayerPrefs.GetInt(highestPlayer2KeyScore, 0);
    }

    public string GetHighestPlayer2()
    {
        return PlayerPrefs.GetString(highestPlayer2Key, "");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

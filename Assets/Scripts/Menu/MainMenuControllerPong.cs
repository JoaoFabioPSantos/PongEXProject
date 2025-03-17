using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuControllerPong : MonoBehaviour
{
    public TextMeshProUGUI uiLastWinner;
    public TextMeshProUGUI uiHighestPlayer1;
    public TextMeshProUGUI uiHighestPlayer2;

    private void Start()
    {
        SaveControllerPong.Instance.Reset();
        string lastWinner = SaveControllerPong.Instance.GetLastWinner();

        string highestPlayer1 = SaveControllerPong.Instance.GetHighestPlayer1();
        string highestPlayer2 = SaveControllerPong.Instance.GetHighestPlayer2();
        
        if(highestPlayer1 != "" || highestPlayer2 != "")
        {
            uiHighestPlayer1.text = "Maior pontua��o: " + highestPlayer1;
            uiHighestPlayer2.text = "Maior pontua��o: " + highestPlayer2;
        }
        else
        {
            uiHighestPlayer1.text = "";
            uiHighestPlayer2.text = "";
        }


        if (lastWinner != "")
        {
            uiLastWinner.text = "�ltimo Ganhador: " + lastWinner;
        }
        else
        {
            uiLastWinner.text = "";
        }
    
    }

}

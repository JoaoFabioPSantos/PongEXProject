using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButtonPong : MonoBehaviour
{
    [Header("Player Reference")]
    public Image paddleReference;
    public bool isColorPlayer = false;
    public int idCount = 1;

    [Header("Color Reference")]
    public Image colorReference;
    public Animator colorReferenceAnimation;

    public Dictionary<int, Color> orderColor = new Dictionary<int, Color>()
    {
        {1, Color.white},
        {2, Color.green},
        {3, Color.blue},
        {4, Color.cyan},
        {5, Color.magenta},
        {6, Color.yellow},
        {7, Color.red},
    };

    public void OnButtonClick(bool isNextColor)
    {

        if(isNextColor)
        {
            idCount++;
            ChangeColor(idCount);
        }
        else
        {
            idCount--;
            ChangeColor(idCount);
        }

        colorReferenceAnimation.Play("ColorIdle");

        paddleReference.color = colorReference.color;
       
        if (isColorPlayer)
        {
            SaveControllerPong.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveControllerPong.Instance.colorEnemy = paddleReference.color;
        }
    }

    public void ChangeColor(int newColor)
    {
        colorReferenceAnimation.Play("ColorBounce");
        if (newColor > 7)
        {
            newColor = 1;
            idCount = 1;
        }
        else if(newColor < 1)
        {
            newColor = 7;
            idCount = 7;
        }
        colorReference.color = orderColor[newColor];
       
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputNamePong : MonoBehaviour
{
    public bool isPlayer = false;
    public TMP_InputField inputField;

    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    public void UpdateName(string name)
    {
        if (isPlayer)
        {
            SaveControllerPong.Instance.namePlayer = name;
        }
        else
        {
            SaveControllerPong.Instance.nameEnemy = name;
        }
    }
}

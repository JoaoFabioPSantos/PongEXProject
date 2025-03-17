using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataPong : MonoBehaviour
{
    public void ClearData()
    {
        SaveControllerPong.Instance.ClearSave();
    }
}

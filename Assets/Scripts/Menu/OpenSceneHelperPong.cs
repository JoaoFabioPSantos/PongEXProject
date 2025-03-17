using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneHelperPong : MonoBehaviour
{
    public string gameScene;

    public void OpenScene()
    {
        SceneManager.LoadScene(gameScene);
    }
}

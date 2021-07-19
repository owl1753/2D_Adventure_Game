using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public void GameStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("FirstStage");
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}

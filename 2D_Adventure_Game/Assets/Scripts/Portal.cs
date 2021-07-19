using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameManager gm;
    public string sceneName;
    public Vector2 spawnPoint;
    public bool usingPortal;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            usingPortal = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            usingPortal = false;
        }
    }

    void OnEnterStay2D(Collider2D cd)
    {
        if (cd.CompareTag("Player") && usingPortal)
        {
            gm.Save();
            gm.spawnPoint = spawnPoint;
            SceneManager.LoadSceneAsync(sceneName);
        }
    }

    void OnTriggerStay2D(Collider2D cd)
    {
        if (cd.CompareTag("Player") && usingPortal)
        {
            gm.Save();
            gm.spawnPoint = spawnPoint;
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

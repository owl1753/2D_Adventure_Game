using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public AudioManager ad;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI expText;
    public Vector2 spawnPoint;
    public Quaternion playerAngle;

    void Awake()
    {
        var obj = FindObjectsOfType<GameManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region OnLoad
    void Start()
    {
        ad.Play("MainTheme");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = FindObjectOfType<Player>();
        Load();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    #endregion

    void Update()
    {
        levelText.text = "Level : " + player.level;
        damageText.text = "Damage : " + player.damage;
        expText.text = "Exp : " + player.exp + " / " + player.maxExp;
        playerAngle = player.transform.rotation;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Level", player.level);
        PlayerPrefs.SetFloat("Damage", player.damage);
        PlayerPrefs.SetInt("Exp", player.exp);
        PlayerPrefs.SetInt("MaxExp", player.maxExp);
        PlayerPrefs.SetFloat("spawnPointX", spawnPoint.x);
        PlayerPrefs.SetFloat("spawnPointY", spawnPoint.y);
        PlayerPrefs.SetFloat("playerAngleY", playerAngle.eulerAngles.y);
        Debug.Log(playerAngle.y);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            player.level = PlayerPrefs.GetInt("Level");
            player.damage = PlayerPrefs.GetFloat("Damage");
            player.exp = PlayerPrefs.GetInt("Exp");
            player.maxExp = PlayerPrefs.GetInt("MaxExp");
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("spawnPointX"), PlayerPrefs.GetFloat("spawnPointY"));
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, PlayerPrefs.GetFloat("playerAngleY"), player.transform.rotation.z); ;
        }
    }
}

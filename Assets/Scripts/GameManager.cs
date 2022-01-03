using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    [Header("Game objects")]
    [SerializeField] private Coin coin;
    [SerializeField] private Rock Rock1;
    [SerializeField] private Rock Rock2;
    [SerializeField] private Rock Rock3;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private GameObject retryMenu;
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);
        Assert.IsNotNull(scoreMenu);
    }

    void Start()
    {
        scoreMenu.SetActive(false);
        retryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + player.score;
    }

    public void PlayerCollided()
    {
        playerActive = false;
        gameOver = true;
        retryMenu.SetActive(true);
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {

        mainMenu.SetActive(false);
        scoreMenu.SetActive(true);
        gameStarted = true;
    }

    public void RestartGame()
    {
        
        player.score = 0;
        player.RestartPlayer();
        Rock1.RestartRock();
        Rock2.RestartRock();
        Rock3.RestartRock();
        coin.RestartCoin();
        gameOver = false;
        retryMenu.SetActive(false);

    }
    
}

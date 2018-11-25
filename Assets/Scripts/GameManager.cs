using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : GenericSingletonClass<GameManager> {

    public bool playBG = false;
    public bool playTap = false;
    public bool canPress = false;
    public bool gameOver = false;

    public Text gameOverText;

    [SerializeField] private GameObject gameOverUI;
    
    void Start () {
		
	}

    private void OnEnable()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update () {
        if (gameOver)
        {
            gameOverUI.SetActive(true);
            canPress = false;
        }
	}

    public void loadSelfScene()
    {
        canPress = false;
        gameOver = false;
        SceneManager.LoadScene("Game");
    }
}

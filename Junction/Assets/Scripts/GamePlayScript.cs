using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

    private bool canPress = false;

    private int ggCount = 0;
    private int bgCount = 0;

    private float timeLeft = int.MaxValue;

    [SerializeField] private GameObject[] toActivateGOs;

    [SerializeField] private Text goodScoreText;
    [SerializeField] private Text badScoreText;

    void Start () {
        Invoke("startGame",2f);
	}
	
    void Update () {
        if (canPress)
        {
            countDown();
            detectKeyPress();
        }
    }

    private void startGame()
    {
        toggleActiveState();
        canPress = true;
    }

    private void detectKeyPress()
    {
        
            if (Input.GetKeyUp(KeyCode.A))
            {
                ggCount++;
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                bgCount++;
            }
        updateScore();
    }

    private void countDown()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        canPress = false;
        toggleActiveState();
        updateScore();
    }

    private void toggleActiveState()
    {
        foreach (GameObject obj in toActivateGOs)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }

    private void updateScore()
    {
        goodScoreText.text = "Good: " + ggCount;
        badScoreText.text = "Bad: " + bgCount;
    }
}

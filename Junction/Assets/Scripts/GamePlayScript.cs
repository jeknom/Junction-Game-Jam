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

    [SerializeField] private GameObject goodScoreSp;
    [SerializeField] private GameObject badScoreSp;
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
            //updateScore();



            goodScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 1;
            badScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 0;


            goodScoreSp.transform.localScale = Vector3.Lerp(goodScoreSp.transform.localScale, (goodScoreSp.transform.localScale 
                + new Vector3((1f),0, 0)), Time.deltaTime * 1f);
            badScoreSp.transform.localScale = Vector3.Lerp(badScoreSp.transform.localScale, (badScoreSp.transform.localScale
               - new Vector3((1f),0, 0)), Time.deltaTime * 1f);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            bgCount++;
            //updateScore();
            goodScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 0;
            badScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 1;

            badScoreSp.transform.localScale = Vector3.Lerp(badScoreSp.transform.localScale, (badScoreSp.transform.localScale
               + new Vector3((1f), 0, 0)), Time.deltaTime * 1f);
            goodScoreSp.transform.localScale = Vector3.Lerp(goodScoreSp.transform.localScale, (goodScoreSp.transform.localScale
                - new Vector3((1f),0, 0)), Time.deltaTime * 1f);

        }
        
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

        if (ggCount > bgCount)
        {
            goodScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 1;
            badScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 0;

            goodScoreSp.transform.localScale += new Vector3((ggCount-bgCount) * Time.deltaTime * 5f, 0);
            badScoreSp.transform.localScale += new Vector3( (-(ggCount - bgCount) * Time.deltaTime * 5f), 0);
        }

        else if (ggCount < bgCount)
        {
            goodScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 0;
            badScoreSp.GetComponent<SpriteRenderer>().sortingOrder = 1;

            badScoreSp.transform.localScale += new Vector3( (bgCount - ggCount) * Time.deltaTime * 5f, 0);
            goodScoreSp.transform.localScale += new Vector3(-((bgCount - ggCount) * Time.deltaTime * 5f), 0);
        }
    }
}

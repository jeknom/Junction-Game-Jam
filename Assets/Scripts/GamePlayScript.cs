using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

    private int ggCount = 0;
    private int bgCount = 0;

    //public int tries = int.MaxValue;

    private float timeLeft = int.MaxValue;

    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject[] tasks;

    [SerializeField] private Text goodScoreText;
    [SerializeField] private Text badScoreText;
    [SerializeField] private Text triesText;

    [SerializeField] private GameObject backgroundMask;
    [SerializeField] private GameObject[] buttonImages;

    void Start () 
    {
        StartCoroutine(SmashIndicator());
        Invoke("startGame",0.0f);
	}
	
    void Update () {
        /* if (tries <= 0)
         {
             canPress = false;
         }
        */
        if (GameManager.Instance.gameOver)
        {
            stopPlayersAnims();
        }
        if (GameManager.Instance.canPress)
        {
            countDown();
            detectKeyPress();
        }
    }

    private void startGame()
    {
        GameManager.Instance.canPress = true;
        
    }

    private void detectKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.playTap = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            ggCount++;
            //tries -= 1;
            updateScore(0.1f);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            bgCount++;
            //tries -= 1;
            updateScore(-0.1f);
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
        GameManager.Instance.gameOver = true;
        /*toggleActiveState();*/
        //updateScore();
    }

    private void toggleActiveState()
    {
        foreach (GameObject obj in players)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }

    private void updateScore(float val)
    {
        goodScoreText.text = "Good: " + ggCount;
        badScoreText.text = "Bad: " + bgCount;
        //triesText.text = "Tries: " + tries;

        iTween.ScaleTo(backgroundMask, iTween.Hash("x", backgroundMask.transform.localScale.x + val, "default", .1));

        if (backgroundMask.transform.localScale.x + val > 1 && !tasks[2].activeInHierarchy)
        {
            tasks[2].SetActive(true);
            tasks[3].SetActive(false);
        }
        else if (backgroundMask.transform.localScale.x + val < 1 && !tasks[3].activeInHierarchy)
        {
            tasks[2].SetActive(false);
            tasks[3].SetActive(true);
        }
      
        
        foreach (GameObject obj in players)
        {
            iTween.MoveTo(obj, iTween.Hash("x", obj.transform.position.x + (val * 8.9f), "default", .1));   
        }
    }

    void stopPlayersAnims()
    {
        foreach (GameObject obj in players)
        {
            obj.GetComponent<Animator>().enabled = false;
        }
    }

    private IEnumerator SmashIndicator()
    {
        foreach (var image in buttonImages)
            image.SetActive(true);

        yield return new WaitForSeconds(3f);

        foreach (var image in buttonImages)
            image.SetActive(false);
    }
    
}
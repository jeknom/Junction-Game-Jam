using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    [SerializeField] private GameObject introSFX;
    [SerializeField] private GameObject bgSFX;
    [SerializeField] private GameObject tapSFX;
    void Start () {
        Invoke("startSound",1f);
	}

    private void Update()
    {
        if (GameManager.Instance.playBG)
        {
            startBGSound();
            GameManager.Instance.playBG = false;
        }
        if (GameManager.Instance.playTap)
        {
            tapSound();
        }
    }
    private  void startSound()
    {
        introSFX.SetActive(true);
    }

    private void startBGSound()
    {
        bgSFX.SetActive(true);
    }

    private void tapSound()
    {
        tapSFX.GetComponent<AudioSource>().PlayOneShot(tapSFX.GetComponent<AudioSource>().clip);
        GameManager.Instance.playTap = false;
    }
}

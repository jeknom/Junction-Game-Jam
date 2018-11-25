using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    [SerializeField] private GameObject GameScene;
    [SerializeField] private GameObject introScene;
    [SerializeField] private GameObject backgroundMask;
	[SerializeField] private GameObject blueSky;
	[SerializeField] private GameObject redSky;

	public GameObject MainGuy;
	public GameObject GoodGuy;
	public GameObject BadGuy;

	IEnumerator Start () 
	{
       
		var mainGuy = Instantiate(MainGuy, new Vector3(-10,-5,0), Quaternion.identity);
		mainGuy.transform.localScale = new Vector3(0.5f, 0.5f, 0);

		while (backgroundMask.transform.localScale.x > 1f || mainGuy.transform.position.x < 0)
		{
			mainGuy.transform.position = Vector3.MoveTowards(mainGuy.transform.position, new Vector3(0, -5, 0), 0.1f);

			backgroundMask.transform.localScale = Vector3.MoveTowards(backgroundMask.transform.localScale, 
				new Vector3(0.1f, backgroundMask.transform.localScale.y), 0.55f * Time.deltaTime);
			yield return new WaitForSeconds(0.00001f);
		}

		for (var i = 0; i < 10; i++)
		{
			blueSky.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
			redSky.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
			yield return new WaitForSeconds(0.05f);

			blueSky.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			redSky.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
			yield return new WaitForSeconds(0.05f);
		}

		blueSky.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 160, 255);
		redSky.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);

		Destroy(mainGuy);

		var goodGuy = Instantiate(GoodGuy, new Vector3(0,-3,0), Quaternion.identity);
		var badGuy = Instantiate(BadGuy, new Vector3(0,-3,0), Quaternion.identity);

		goodGuy.transform.localScale = new Vector3(0.4f, 0.4f, 0);
		badGuy.transform.localScale = new Vector3(-0.4f, 0.4f, 0);

        goodGuy.transform.parent = introScene.transform;
        badGuy.transform.parent = introScene.transform;


        while (goodGuy.transform.position.x > -1.9 || badGuy.transform.position.x < 1.9)
		{
			goodGuy.transform.position = Vector3.MoveTowards(goodGuy.transform.position, new Vector3(-2,-4.5f,0), 0.1f);
			badGuy.transform.position = Vector3.MoveTowards(badGuy.transform.position, new Vector3(2,-4.5f,0), 0.1f);
			yield return new WaitForSeconds(0.01f);
		}

		GameScene.SetActive(true);
        GameManager.Instance.playBG = true;
        Destroy(introScene);
	}
}

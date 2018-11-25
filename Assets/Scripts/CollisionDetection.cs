using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Contains(this.gameObject.tag))
        {
            GameManager.Instance.gameOver = true;
            if (this.gameObject.tag == "Bad")
            {
                GameManager.Instance.gameOverText.text = "No good deed goes unpunished. Be evil instead."; 
            }
            else if (this.gameObject.tag == "Good")
            {
                GameManager.Instance.gameOverText.text = "You've overcome human nature. You're a \"good\" person";
            }
        }
    }
}

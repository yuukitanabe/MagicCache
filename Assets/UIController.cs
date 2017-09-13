using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private GameObject gameOverText;

    private bool isGameOver = false;


	// Use this for initialization
	void Start () {

        this.gameOverText = GameObject.Find("GameOver");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    public void GameOver()
    {
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}

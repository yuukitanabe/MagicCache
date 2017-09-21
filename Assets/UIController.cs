using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private GameObject gameOverText;

    private bool isGameOver = false;

    private bool isClear = false;


	// Use this for initialization
	void Start () {

        this.gameOverText = GameObject.Find("GameOver");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver || this.isClear)
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
    public void Clear()
    {
        this.gameOverText.GetComponent<Text>().text = "CLEAR!";
        this.isClear = true;
    }
}

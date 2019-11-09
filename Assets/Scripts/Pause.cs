using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject pause;
    public GameObject gameOver;
    public Levels levels;

    private int record;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape) && !gameOver.activeSelf)
        {
            if (!pause.activeSelf) Time.timeScale = 0;
            else Time.timeScale = 1;
            pause.SetActive(!pause.activeSelf);
        }
	}

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);

        record = PlayerPrefs.GetInt("record");
        if (levels.GetScore() > record)
        {
            record = levels.GetScore();
            PlayerPrefs.SetInt("record", record);
        }

        gameOver.transform.GetChild(0).GetComponent<Text>().text = "Result: " + levels.GetScore();
        gameOver.transform.GetChild(1).GetComponent<Text>().text = "Record: " + record;
    }
}

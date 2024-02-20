using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Text gameOverText;

    public GameObject player;

    PlayerMove playerMove;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == false)
        {
            gameOverCanvas.SetActive(true);
            gameOverText.text = "High Score : " + playerMove.highScore + "\nReturn to Start";
            PlayerPrefs.SetInt("HighScore", playerMove.highScore);

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
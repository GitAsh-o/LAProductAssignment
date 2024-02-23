using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float speed = 12.0f;
    public int score = 0;
    public int highScore;
    bool isGravity = true;
    public bool isPlaying = false;

    public GameObject mainCamera;
    public ParticleSystem particle;
    public ParticleSystem endParticle;
    private Rigidbody rb;

    public Text titleText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop (true, ParticleSystemStopBehavior.StopEmitting);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        scoreText.enabled = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                titleText.enabled = false;
                scoreText.enabled = true;
                isPlaying = true;
                particle.Play();
                rb.useGravity = true;
                Physics.gravity = new Vector3(0, -90, 0);
            }
        }
        else if (isPlaying == true)
        {
            scoreText.text = score.ToString();

            // プレイヤーとカメラとパーティクルの移動
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

            mainCamera.transform.position = new Vector3(transform.position.x, 0, -10);
            // - Destroyの後も残っていて欲しいのでparticle系はscriptで移動させる。
            particle.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            endParticle.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            //マウスボタンで重力切り替え
            if (Input.GetMouseButtonDown(0))
            {
                if (isGravity == true)
                {
                    rb.velocity = new Vector3(0, 14, 0);
                    Physics.gravity = new Vector3(0, 90, 0);
                    isGravity = false;
                }
                else if (isGravity == false)
                {
                    rb.velocity = new Vector3(0, -14, 0);
                    Physics.gravity = new Vector3(0, -90, 0);
                    isGravity = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            if (score >= highScore)
            {
                highScore = score;
            }
            particle.Stop (true, ParticleSystemStopBehavior.StopEmitting);
            endParticle.Play();
            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Point")
        {
            Destroy(other.gameObject);
            score ++;
        }
    }
}

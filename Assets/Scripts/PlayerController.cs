using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        score = 0;
        SetScoreText();
        
 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score + 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Bad up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score - 1;
            SetScoreText();
        }


    }






    void SetCountText()

    {
        countText.text = "<b>Count:</b> " + count.ToString();
        if (count >= 20)
        {
            winText.text = "<b>You Win!</b>";
        }
        if (count >= 10)
        {
            winText.text = "<b>Loading Second Level</b>";
            SceneManager.LoadScene("Second Level");
        }
    }
    void SetScoreText()

    {
        scoreText.text = "<b>Score:</b> " + score.ToString();
        if (score >= 10)
        {
            winText.text = "<b>GoodJob!</b>";
        }







    }
}
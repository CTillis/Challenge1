using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    private int level;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        level = 1;
        winText.text = "";
        SetCountText1();
        SetLivesText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if (level == 1)
            {
                SetCountText1();
            }
            if (level == 2)
            {
                SetCountText2();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetCountText1()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            count = 0;
            countText.text = "Count: " + count.ToString();
            level = 2;
            transform.position = new Vector2(1.40f, 79.8f);
        }
    }

    void SetCountText2()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win! Game created by Chris Tillis.";
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Lose!";
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetAllText();
        winText.text = "";
        loseText.text = "";
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
               other.gameObject.SetActive(false);
          count = count + 1; 
          score = score + 1;
          SetAllText();
     }
     else if (other.gameObject.CompareTag("Enemy"))
     {
          other.gameObject.SetActive(false);
          //count = count + 1;  comment out for tier three win to work, but was requirement for tier 2 so I am keeping it in
          score = score - 1; // this removes 1 from the score
          lives = lives - 1;
          SetAllText();
        }

        if (count == 12)
{
    transform.position = new Vector3(-70.0f, 0.5f, 3.0f); 
}
    }
    void SetAllText()
    {
        scoreText.text = "Score: " + score.ToString();
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();
            if (count>=20)
        {
            winText.text = "You Win!";
        }
        if (lives == 0)
        {
            Destroy(this.gameObject);
            loseText.text = "You Lose!";
        }
    }
}

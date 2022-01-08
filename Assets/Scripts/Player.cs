using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject cam;
    public GameObject shield;
    public Text textScore;

    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip shieldSound;

    bool isOnGround;
    public float jumpForce = 800;
    public float timer;
    public int score;
    public int coin;

    public static bool GameIsOver = false;
    public GameObject overUI;

    void Start()
    {
        transform.position = new Vector3(cam.transform.position.x - 4, transform.position.y, transform.position.z);
        score = 0;
        timer = 0;
        coin = PlayerPrefs.GetInt("totalCoin");
        GameIsOver = false;
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x - 6, transform.position.y, transform.position.z);
        shield.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 0.4f, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isOnGround = false;
        }
        timer += Time.deltaTime;
        if (timer >= 0.01)
        {
            score += 1;
            timer = 0;
        }
        textScore.text = "score = " + score + "\nmax score = " + PlayerPrefs.GetInt("maxScore") + "\nCoin = " + coin;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.tag == "ground")
            isOnGround = true;
        else
            isOnGround = false;

        if (coll.collider.tag == "cow" && transform.position.y < -1.5)
        {
            GetComponent<AudioSource>().clip = deathSound;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("totalCoin", coin);
            if (PlayerPrefs.GetInt("maxScore") < score)
                PlayerPrefs.SetInt("maxScore", score);
            overUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsOver = true;
        } else if (coll.collider.tag == "cow" && transform.position.y > -1.5)
        {
            isOnGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().clip = coinSound;
            GetComponent<AudioSource>().Play();
            Destroy(hit.gameObject);
            coin++;
        }

        if (hit.CompareTag("Shield"))
        {
            GetComponent<AudioSource>().clip = shieldSound;
            GetComponent<AudioSource>().Play();
            Destroy(hit.gameObject);
            shield.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    float timer = 0;
    private int shieldLevel;
    private float maxTime;

    void Start()
    {
        shieldLevel = PlayerPrefs.GetInt("shieldLevel");
        maxTime = 5f + (0.5f * shieldLevel);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (maxTime - timer <= 1) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(183, 0, 0);
        }
        if (timer >= maxTime){
            gameObject.SetActive(false);
            timer = 0;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "cow")
        {
            coll.gameObject.transform.position = new Vector3(coll.gameObject.transform.position.x - 10, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
        }
    }
}

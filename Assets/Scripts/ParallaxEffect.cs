using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float speed;
    public float timer = 1000;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused || Player.GameIsOver)
            return;
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;

        Vector3 pos = new Vector3(speed + cam.transform.position.x, 0, -10.0f);
        Camera.main.gameObject.transform.position = pos;

        timer -= 1;
        if (timer <= 0)
        {
            timer = 1000;
            speed += 0.001f;
        }
    }
}

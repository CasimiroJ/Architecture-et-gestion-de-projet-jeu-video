using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cow : MonoBehaviour
{

    public GameObject cam;
    bool active;
    public float time;
    public float nextCow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= nextCow)
        {
            transform.position = new Vector3(cam.transform.position.x + 10, transform.position.y, transform.position.z);
            time = 0;
            nextCow = Random.Range(3, 5);
        }
    }
}

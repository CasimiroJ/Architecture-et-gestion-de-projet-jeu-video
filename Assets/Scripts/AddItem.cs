using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject cam;
    public GameObject coin;
    public GameObject shield;
    public float timerCoin = 0;
    public float timer = 0;
    public float nextCoin = 1;
    public float nextUpgrade = 10;

    void Start()
    {
        
    }

    void Update()
    {
        timerCoin += Time.deltaTime;
        timer += Time.deltaTime;
        if (timerCoin >= nextCoin)
        {
            addItemOnMap(coin);
            nextCoin = Random.Range(3, 5);
            timerCoin = 0;
        }
        if (timer >= nextUpgrade)
        {
            addItemOnMap(shield);
            nextUpgrade = Random.Range(15, 20);
            timer = 0;
        }
    }

    void addItemOnMap(GameObject obj)
    {
        Vector3 pos;

        if (Random.Range(1, 4) == 2)
        {
            pos = new Vector3(cam.transform.position.x + 20, -1, 10);
        } else {
            pos = new Vector3(cam.transform.position.x + 20, -3, 10);
        }
        GameObject newItem = Instantiate(obj, pos, Quaternion.identity);
        Destroy(newItem, 4f);
    }
}

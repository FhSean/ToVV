using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DifferentPath : MonoBehaviour
{
    private Vector3 pathPos;
    public GameObject OlympicPath;
    public float time;
    public TimeSpan currenttime;
    public int days;

    public int speed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeTime();
        if (time > 32400)
        {
            pathPos = gameObject.transform.position;
            Destroy(gameObject);
        }
        if (time > 54000)
        {
            Instantiate(OlympicPath, pathPos, transform.rotation);
        }
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            days += 1;
            time = 0;
        }
        currenttime = TimeSpan.FromSeconds(time);
    }
}
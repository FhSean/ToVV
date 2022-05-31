using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera01 : MonoBehaviour
{
    private Camera camera01;
    private float rot;
    private float size=3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot = Input.GetAxis("Horizontal");
        size += Input.GetAxis("Vertical");
        if (size>=50f)
        {
            size = 50f;
        }
        if (size<=3f)
        {
            size = 3f;
        }
        this.transform.Rotate(Vector3.up, rot * Time.deltaTime);
        camera01 = this.transform.GetComponentInChildren<Camera>();
        camera01.orthographicSize = size;
    }
}

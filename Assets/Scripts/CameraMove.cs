using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float moveForward;
    private float moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveForward = Input.GetAxis("Vertical");
        moveLeft = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * moveForward * 5f + Vector3.right * Time.deltaTime * moveLeft * 5f);
    }
}

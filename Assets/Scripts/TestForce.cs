using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{
    public GameObject Dir;
    public Vector3 dir;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Dir.transform.forward;
        if (Input.GetButtonDown("West"))
        {
            _rb.AddForce(dir*100, ForceMode.VelocityChange);
        }
        Debug.DrawRay(transform.position, dir * 100, Color.blue);
    }
}

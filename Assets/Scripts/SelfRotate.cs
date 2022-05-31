using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    [Tooltip("Angular velocity in degrees per seconds")]
    public float degPerSec = 60.0f;

    [Tooltip("Rotation axis")]
    private Vector3 rotAxis = Vector3.forward;

    private float angleX;
    private float angleY;
    private float angleZ;
    // Start is called before the first frame update
    void Start()
    {
        angleX = Random.Range(-180f, 180f);
        angleY = Random.Range(-180f, 180f);
        angleZ = Random.Range(-180f, 180f);
        transform.rotation= Quaternion.Euler(angleX, angleY, angleZ);
        rotAxis.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotAxis, degPerSec * Time.deltaTime);
    }
}

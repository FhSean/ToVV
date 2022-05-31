using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    [HideInInspector]
    public Vector3 rotH;
    [SerializeField]
    private float rSensitivityH = 20f;
    [SerializeField]
    private float deadZone = 0.1f;

    private float _rInputH;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);

        _rInputH = Input.GetAxis("RightJoyX");
        //Debug.Log(this.transform.localRotation.eulerAngles.y);
        if (_rInputH >= deadZone)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0f, _rInputH * rSensitivityH, 0f));
            /*if (this.transform.localRotation.eulerAngles.y > 270f)
            {
                transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
            }*/
        }
        if (_rInputH <= -deadZone)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0f, _rInputH * rSensitivityH, 0f));
            /*if (this.transform.localRotation.eulerAngles.y < 90f)
            {
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            }*/
        }
    }
}

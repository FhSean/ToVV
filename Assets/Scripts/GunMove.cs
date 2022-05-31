using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [HideInInspector]
    public Vector3 pos;

    public GameObject Cube;

    [SerializeField]
    private float mSensitivity=20f;
    [SerializeField]
    private float deadZone = 0.1f;

    private float _mInput;
    private float _mLimit;

    // Start is called before the first frame update
    void Start()
    {
        _mLimit = Cube.transform.localScale.z;
        //Debug.Log(_mLimit);
    }

    // Update is called once per frame
    void Update()
    {
        _mInput = Input.GetAxis("Horizontal");
        
        
        //Debug.Log(Time.deltaTime * _mInput * mSensitivity);

        if (Mathf.Abs(_mInput)>=deadZone)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _mInput * mSensitivity);
            if (this.transform.position.z > _mLimit/2f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _mLimit / 2f);
            }
            if (this.transform.position.z < -_mLimit / 2f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -_mLimit / 2f);
            }
        }

        /*if (Mathf.Abs(_rInputH) >= deadZone)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rInputH * rSensitivityH);
            //Debug.Log(transform.rotation.eulerAngles.y);
            if (this.transform.rotation.eulerAngles.y > 150f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 150f, transform.rotation.eulerAngles.z);
            }
            if (this.transform.rotation.eulerAngles.y < 30f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 30f, transform.rotation.eulerAngles.z);
            }
        }

        if (Mathf.Abs(_rInputV) >= deadZone)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * -_rInputV * rSensitivityH);
            Debug.Log(transform.rotation.eulerAngles.x);
            if (this.transform.rotation.eulerAngles.x > 360f)
            {
                transform.rotation = Quaternion.Euler(360f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            if (this.transform.rotation.eulerAngles.x < 270f)
            {
                transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

        }*/
        
        //Debug.Log(_rInputV * rSensitivityV);

    }
}

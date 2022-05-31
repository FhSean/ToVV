using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLift : MonoBehaviour
{
    [HideInInspector]
    public Vector3 rotV;
    [SerializeField]
    private float rSensitivityV = 20f;
    [SerializeField]
    private float deadZone = 0.1f;
    private float _rInputV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        _rInputV = Input.GetAxis("RightJoyY");
        //Debug.Log(this.transform.localRotation.eulerAngles.z);
        if (_rInputV >= deadZone)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0f, 0f, _rInputV * rSensitivityV));
            if (this.transform.localRotation.eulerAngles.z > 270f)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 270f);
            }
        }
        if (_rInputV <= -deadZone&& this.transform.localRotation.eulerAngles.z>180f)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(0f, 0f, _rInputV * rSensitivityV));
            if (this.transform.localRotation.eulerAngles.z <= 180f)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 180f);
            }
        }

    }
}

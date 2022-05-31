using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTest : MonoBehaviour
{
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = (this.transform.position-end.transform.position);
        float raym = v.magnitude;
        //Debug.DrawRay(end.transform.position, v.normalized * raym, Color.blue);
        RaycastHit hit1;
        if (Physics.Raycast(end.transform.position,v.normalized,out hit1,raym))
        {
            Debug.DrawRay(hit1.transform.position, hit1.normal*10f, Color.blue);
            Debug.Log("hit");

        }
    }
}

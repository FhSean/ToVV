using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCaught : MonoBehaviour
{
    public Transform targetObj;
    private GameObject[] legion;
    private FunctionManager fm; 
    private Transform unit;
    private float scale;
    private Vector3 rayD;
    private float rayM;
    private RaycastHit hit;
    private Vector3 pos;
    private TrailRenderer trail;
    private SetUnit su;
    private MagnetCheckUnit mcu;

    private void Start()
    {
        legion = GameObject.FindGameObjectsWithTag("Unit");
        fm = GameObject.FindGameObjectWithTag("FunctionManager").GetComponent<FunctionManager>();
        targetObj = fm.GetNearestGameObject(this.transform, legion);
        unit = this.transform.GetChild(3);
        //从漂浮物中心向最近物体中心发射一条线与最近面相交，从而确定最近面的法向
        rayD = targetObj.position- this.transform.position;
        rayM = rayD.magnitude;
        trail = this.GetComponent<TrailRenderer>();
        mcu = this.GetComponent<MagnetCheckUnit>();
        su = this.GetComponent<SetUnit>();
        //Debug.DrawRay(this.transform.position, rayD.normalized*rayM, Color.blue);
        if (Physics.Raycast(this.transform.position, rayD.normalized, out hit, rayM))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.name.Contains("Square"))
            {
                scale = 0.58f;
            }
            if (hit.transform.gameObject.name.Contains("Hexagon"))
            {
                scale = 0.5023f;
            }
            pos = hit.transform.position + hit.normal * scale;
        }
        if (hit.transform.parent==null)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime*4);
        unit.rotation = Quaternion.Lerp(unit.rotation, Quaternion.identity, Time.deltaTime*5f);
        Vector3 checkD = hit.transform.position - this.transform.position;
        float checkM = checkD.magnitude;
        //Debug.Log(checkM);
        if (checkM <= 0.6f)
        {
            mcu.su.isBusy = false;
            this.transform.position = pos;
            unit.rotation = Quaternion.identity;
            unit.gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.gameObject.tag = "Unit";
            targetObj.gameObject.tag = "Unit";
            su.enabled = true;
            this.enabled = false;
            //trail.enabled = true;
        }

    }

}

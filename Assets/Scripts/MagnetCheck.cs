using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagnetCheck : MonoBehaviour
{
    private GameObject[] legions;//所有的既有单元
    private Transform[] tempFaces;//最近单元的所有子物体
    private List<Transform> faceList;//最近单元的所有面
    private List<float> list;//漂浮物与各既有单元的距离
    private List<float> tempDis;//漂浮物与最近单元各面的距离
    private int _indexM;//最近单元的编号
    private float scale=0.5f;
    private bool isCaught = false;//物体是否正处于被吸引状态

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject subParent = this.transform.GetChild(0).gameObject;
        measures = subParent.transform.GetChild;*/
    }

    // Update is called once per frame
    void Update()
    {
        legions = GameObject.FindGameObjectsWithTag("Unit");

        //计算各既有单元与漂浮物距离
        for (int i = 0; i < legions.Length; i++)
        {
            Vector3 disV1 = legions[i].transform.position - this.transform.position;
            float disM1 = disV1.magnitude;
            list.Add(disM1);
        }

        //找到最近单元并判断与其距离是否达到引力范围
        float minDis1 = list.Min();
        int indexM1 = list.IndexOf(minDis1);
        //legions[indexM];
        if (minDis1 <= 5f)
        {
            isCaught = true;
        }

        //如果达到引力范围，则漂浮物开始被吸引
        if (isCaught)
        {
            _indexM = indexM1;
            GetCaught();
        }


    }
    
    void GetCaught()
    {
        //找到最近单元的所有面
        GameObject targetObj = legions[_indexM];
        Transform sub = targetObj.transform.GetChild(0);
        tempFaces = sub.GetComponentsInChildren<Transform>();
        foreach (Transform item1 in tempFaces)
        {
            if (item1.tag=="Unit")
            {
                faceList.Add(item1);
            }
        }
        foreach (Transform item2 in faceList)
        {
            Vector3 disV2 = item2.transform.position - this.transform.position;
            float disM2 = disV2.magnitude;
            tempDis.Add(disM2);
        }

        //找到最近面theFace
        float minDis2 = tempDis.Min();
        int indexM2 = tempDis.IndexOf(minDis2);
        Transform theFace = faceList[indexM2];

        //从漂浮物中心向最近物体中心发射一条线与最近面相交，从而确定最近面的法向
        Vector3 rayD = this.transform.position - targetObj.transform.position;
        float rayM = rayD.magnitude;
        int magLayerMask = 1;
        RaycastHit hit;
        Vector3 pos = Vector3.zero;
        if (Physics.Raycast(this.transform.position,rayD.normalized,out hit,rayM, magLayerMask))
        {
            pos = hit.transform.position + hit.normal * scale;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.identity, Time.deltaTime);
    }
}

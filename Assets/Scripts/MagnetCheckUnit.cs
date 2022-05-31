using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagnetCheckUnit : MonoBehaviour
{
    public Transform nearestUnit;
    public SetUnit su;
    private GameObject[] legion;//所有的既有单元
    private GetCaught getCaught;
    private SelfMove selfMove;
    private SelfRotate selfRotate;
    private bool isCaught = false;//物体是否正处于被吸引状态
    private bool isBusy;
    private GameObject functionManager;
    private FunctionManager fm;

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject subParent = this.transform.GetChild(0).gameObject;
        measures = subParent.transform.GetChild;*/
        getCaught = this.GetComponent<GetCaught>();
        selfMove = this.GetComponent<SelfMove>();
        selfRotate = this.transform.GetChild(3).GetComponent<SelfRotate>();
        functionManager = GameObject.FindGameObjectWithTag("FunctionManager");
        fm = functionManager.GetComponent<FunctionManager>();
        //Debug.Log(legion.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * 1 * Time.deltaTime);
        /*//计算各既有单元与漂浮物距离
        for (int i = 0; i < legion.Length; i++)
        {
            Vector3 disV1 = legion[i].transform.position - this.transform.position;
            float disM1 = disV1.magnitude;
            Debug.Log(disM1);
            list.Add(disM1);
        }

        //找到最近单元并判断与其距离是否达到引力范围
        float minDis1 = list.Min();
        int indexM1 = list.IndexOf(minDis1);
        //legion[indexM];*/

        legion = GameObject.FindGameObjectsWithTag("Unit");
        if (legion.Length==0)
        {
            return;
        }
        nearestUnit=fm.GetNearestGameObject(this.transform,legion);
        su = nearestUnit.GetComponent<SetUnit>();
        isBusy = su.isBusy;
        Vector3 minDisV1 = this.transform.position - nearestUnit.position;
        float minDisM1 = minDisV1.magnitude;
        if (minDisM1 <= 3f&&!isBusy)
        {
            su.isBusy = true;
            isCaught = true;
        }

        //如果达到引力范围，则漂浮物开始被吸引
        if (isCaught)
        {
            getCaught.enabled = true;
            //Instantiate(tPosition, nearestUnit.position, Quaternion.identity);
            this.enabled = false;
            selfMove.enabled = false;
            selfRotate.enabled = false;
            //trail.enabled = true;
        }


        //Debug.Log(minDisM1);

    }

    

}

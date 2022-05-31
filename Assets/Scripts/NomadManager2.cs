using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NomadManager2 : MonoBehaviour
{
    private GameObject boundary;
    private GameObject functionManager;
    private BoundaryManager bm;
    private FunctionManager fm;
    private InstantiateFloatage insFlo;
    private float disMA;
    public Dictionary<Vector3, List<GameObject>> disTest;

    private Vector3 pos0;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;

    public Vector3[] poses;

    private GameObject[] detach;

    private List<Vector3> corners;

    private void OnEnable()
    {
        boundary = GameObject.FindGameObjectWithTag("BoundaryBox");
        insFlo = boundary.GetComponent<InstantiateFloatage>();
        functionManager = GameObject.FindGameObjectWithTag("FunctionManager");
        bm = boundary.GetComponent<BoundaryManager>();
        fm = functionManager.GetComponent<FunctionManager>();
        float sf = (bm.scaleFactor - 1) * 5f;
        //Debug.Log(sf);
        disTest = new Dictionary<Vector3, List<GameObject>>();

        pos0 = new Vector3(sf, sf, sf);
        pos1 = new Vector3(-sf, sf, sf);
        pos2 = new Vector3(-sf, -sf, sf);
        pos3 = new Vector3(sf, -sf, sf);
        pos4 = new Vector3(sf, sf, -sf);
        pos5 = new Vector3(-sf, sf, -sf);
        pos6 = new Vector3(-sf, -sf, -sf);
        pos7 = new Vector3(sf, -sf, -sf);

        poses = new Vector3[] { pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7 };
        corners = poses.ToList();

        corners[0] = pos0;
        corners[1] = pos1;
        corners[2] = pos2;
        corners[3] = pos3;
        corners[4] = pos4;
        corners[5] = pos5;
        corners[6] = pos6;
        corners[7] = pos7;

        List<GameObject> flockList = new List<GameObject>();
        for (int i = 0; i < 8; i++)
        {
            GameObject go= GameObject.Find("Flock" + i);
            flockList.Add(go);
        }
        detach = flockList.ToArray();

        foreach (Vector3 item in poses)
        {
            disTest.Add(item, new List<GameObject>());
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject flock = detach[i];
            SetUnit[] sus = flock.GetComponentsInChildren<SetUnit>();
            if (sus.Length==0){continue;}
            foreach (SetUnit su in sus)
            {
                GameObject go = su.gameObject;
                float disM = Vector3.Distance(go.transform.position, poses[i]);
                if (disM>8.6f)
                {
                    go.transform.parent = null;
                }
            }
        }

        foreach (GameObject flock in detach)
        {
            SetUnit[] sus = flock.GetComponentsInChildren<SetUnit>();
            int count = sus.Length;
            if (count > 0)
            {
                Vector3 sum = Vector3.zero;
                for (int i = 0; i < count; i++)
                {
                    sus[i].gameObject.GetComponent<SetUnit>().isBusy = true;
                    sum += sus[i].transform.position;
                }
                Vector3 pivot = sum / count;
                flock.transform.position = pivot;
            }
        }

/*        foreach (GameObject go in detach)
        {
            
            Vector3 nearestCorner = fm.FindNearestPoint(go, corners);
            float disM = Vector3.Distance(nearestCorner, go.transform.position);
            for (int i = 0; i < corners.Count; i++)
            {
                if (nearestCorner == corners[i] && disM <= 8.6f)
                {
                    disTest[nearestCorner].Add(go);
                }

            }
        }*/

        /*for (int i = 0; i < 8; i++)
        {
            if (disTest[corners[i]].Count == 0) { continue; }
            Vector3 sum = Vector3.zero;
            for (int a = 0; a < (disTest[corners[i]]).Count; a++)
            {
                sum += disTest[corners[i]][a].transform.position;
            }
            Vector3 pivot = sum / disTest[corners[i]].Count;
            detach[i].transform.position = pivot;
            foreach (GameObject item in disTest[corners[i]])
            {
                item.tag = "NomadUnit";
                item.transform.parent = detach[i].transform;
            }

        }*/
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        disMA = 0;
        for (int i = 0; i < 8; i++)
        {
            detach[i].transform.position= Vector3.Lerp(detach[i].transform.position, poses[i], Time.deltaTime);
            float disM0 = Vector3.Distance(detach[i].transform.position, poses[i]);
            disMA += disM0;
            if (disM0<0.3f)
            {
                detach[i].transform.position = poses[i];
            }
        }


        if (disMA<=0)
        {
            insFlo.enabled = true;
            bm.reachLimit2 = false;
            foreach (GameObject item in detach)
            {
                SetUnit[] sus = item.GetComponentsInChildren<SetUnit>();
                if (sus.Length == 0) { continue; }
                foreach (SetUnit su in sus)
                {
                    su.isBusy = false;
                }
            }
            this.gameObject.SetActive(false);
        }


    }
}

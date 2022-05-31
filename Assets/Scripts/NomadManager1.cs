using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NomadManager1 : MonoBehaviour
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

    public GameObject[] detach;

    private GameObject flock0;
    private GameObject flock1;
    private GameObject flock2;
    private GameObject flock3;
    private GameObject flock4;
    private GameObject flock5;
    private GameObject flock6;
    private GameObject flock7;

    /*private GameObject[] region0;
    private GameObject[] region1;
    private GameObject[] region2;
    private GameObject[] region3;
    private GameObject[] region4;
    private GameObject[] region5;
    private GameObject[] region6;
    private GameObject[] region7;

    private GameObject[] allUnits;

    private List<GameObject> regionl0;
    private List<GameObject> regionl1;
    private List<GameObject> regionl2;
    private List<GameObject> regionl3;
    private List<GameObject> regionl4;
    private List<GameObject> regionl5;
    private List<GameObject> regionl6;
    private List<GameObject> regionl7;

    private List<GameObject> cornerMarks;*/
    private List<Vector3> corners;
    // Start is called before the first frame update
    void Start()
    {

        /*regionl0 = null;
        regionl1 = null;
        regionl2 = null;
        regionl3 = null;
        regionl4 = null;
        regionl5 = null;
        regionl6 = null;
        regionl7 = null;*/

        boundary = GameObject.FindGameObjectWithTag("BoundaryBox");
        insFlo = boundary.GetComponent<InstantiateFloatage>();
        /*for (int i = 0; i < 8; i++)
        {
            GameObject go = Instantiate(Flock, Vector3.zero, Quaternion.identity);
            go.tag = "Flock";
            go.name = "Flock" + i;
        }*/

        /*flock0 = GameObject.Find("Flock" + 0);
        flock1 = GameObject.Find("Flock" + 1);
        flock2 = GameObject.Find("Flock" + 2);
        flock3 = GameObject.Find("Flock" + 3);
        flock4 = GameObject.Find("Flock" + 4);
        flock5 = GameObject.Find("Flock" + 5);
        flock6 = GameObject.Find("Flock" + 6);
        flock7 = GameObject.Find("Flock" + 7);*/

        List<GameObject> flockList = new List<GameObject>();
        for (int i = 0; i < 8; i++)
        {
            GameObject go= GameObject.Find("Flock" + i);
            flockList.Add(go);
        }

        detach = flockList.ToArray();
        //Debug.Log(detach.Length);
        functionManager = GameObject.FindGameObjectWithTag("FunctionManager");
        bm = boundary.GetComponent<BoundaryManager>();
        fm = functionManager.GetComponent<FunctionManager>();
        float sf = (bm.scaleFactor-1) * 5f;
        //Debug.Log(sf);
        disTest = new Dictionary<Vector3, List<GameObject>>();
        //List<GameObject> tempList = new List<GameObject>();
        //allUnits = bm.units;

        pos0 = new Vector3(sf, sf, sf);
        pos1 = new Vector3(-sf, sf, sf);
        pos2 = new Vector3(-sf, -sf, sf);
        pos3 = new Vector3(sf, -sf, sf);
        pos4 = new Vector3(sf, sf, -sf);
        pos5 = new Vector3(-sf, sf, -sf);
        pos6 = new Vector3(-sf, -sf, -sf);
        pos7 = new Vector3(sf, -sf, -sf);

        //Debug.Log(pos0);
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

        foreach (Vector3 item in poses)
        {
            disTest.Add(item, new List<GameObject>());
        }

        //Debug.Log(disTest.Count);

        /*disTest[pos0] = bm.units.ToList();
        disTest[pos1] = bm.units.ToList();
        disTest[pos2] = bm.units.ToList();
        disTest[pos3] = bm.units.ToList();
        disTest[pos4] = bm.units.ToList();
        disTest[pos5] = bm.units.ToList();
        disTest[pos6] = bm.units.ToList();
        disTest[pos7] = bm.units.ToList();*/

        //find closest point
        foreach (GameObject go in bm.units)
        {
            Vector3 nearestCorner = fm.FindNearestPoint(go, corners);
            //Debug.Log(nearestCorner);
            //Debug.Log(go);
            float disM = Vector3.Distance(nearestCorner, go.transform.position);
            for (int i = 0; i < corners.Count; i++)
            {
                //Debug.Log(corners[i]);
                //Debug.Log(disTest[corners[i]]);
                if (nearestCorner == corners[i] && disM <= 8.6f)
                {
                    disTest[nearestCorner].Add(go);
                    //Debug.Log(disTest[v].Count);
                }

            }
        }

        //Debug.Log(disTest[corners[0]]);

        //set parent
        for (int i = 0; i < 8; i++)
        {
            //Debug.Log(i + ": " + disTest[corners[i]].Count);
            if (disTest[corners[i]].Count == 0) { continue; }
            Vector3 sum = Vector3.zero;
            for (int a = 0; a < (disTest[corners[i]]).Count; a++)
            {
                sum += disTest[corners[i]][a].transform.position;
            }
            Vector3 pivot = sum / disTest[corners[i]].Count;
            detach[i].transform.position = pivot;
            //Debug.Log(disTest[corners[i]].Count);
            foreach (GameObject item in disTest[corners[i]])
            {
                item.GetComponent<SetUnit>().isBusy = true;
                item.transform.parent = detach[i].transform;
            }

        }


        /*  foreach (GameObject item in bm.units)
          {
              if (item.transform.position.x > 0 && item.transform.position.y > 0 && item.transform.position.z > 0)
              {
                  regionl1.Add(item);
              }
              else  if (item.transform.position.x < 0 && item.transform.position.y > 0 && item.transform.position.z > 0)
              {
                  regionl2.Add(item);
              }
              else if (item.transform.position.x < 0 && item.transform.position.y < 0 && item.transform.position.z > 0)
              {
                  regionl3.Add(item);
              }
              else if (item.transform.position.x > 0 && item.transform.position.y < 0 && item.transform.position.z > 0)
              {
                  regionl4.Add(item);
              }
              else if (item.transform.position.x > 0 && item.transform.position.y > 0 && item.transform.position.z < 0)
              {
                  regionl5.Add(item);
              }
              else if (item.transform.position.x < 0 && item.transform.position.y > 0 && item.transform.position.z < 0)
              {
                  regionl6.Add(item);
              }
              else if (item.transform.position.x < 0 && item.transform.position.y < 0 && item.transform.position.z < 0)
              {
                  regionl7.Add(item);
              }
              else if (item.transform.position.x > 0 && item.transform.position.y < 0 && item.transform.position.z < 0)
              {
                  regionl8.Add(item);
              }
          }*/

        /*for (int i = 0; i < regionl0.Count; i++)
        {
            flock0 += regionl0[i].transform.position;
        }
        detach0.transform.position = flock0 / (regionl0.Count);
        for (int i = 0; i < regionl1.Count; i++)
        {
            flock1+= regionl1[i].transform.position;
        }
        detach1.transform.position = flock1 / (regionl1.Count);
        for (int i = 0; i < regionl2.Count; i++)
        {
            flock2 += regionl2[i].transform.position;
        }
        detach2.transform.position = flock2 / (regionl2.Count);
        for (int i = 0; i < regionl3.Count; i++)
        {
            flock3 += regionl3[i].transform.position;
        }
        detach3.transform.position = flock3 / (regionl3.Count);
        for (int i = 0; i < regionl4.Count; i++)
        {
            flock4 += regionl4[i].transform.position;
        }
        detach4.transform.position = flock4 / (regionl4.Count);
        for (int i = 0; i < regionl5.Count; i++)
        {
            flock5 += regionl5[i].transform.position;
        }
        detach5.transform.position = flock5 / (regionl5.Count);
        for (int i = 0; i < regionl6.Count; i++)
        {
            flock6 += regionl6[i].transform.position;
        }
        detach6.transform.position = flock6 / (regionl6.Count);
        for (int i = 0; i < regionl7.Count; i++)
        {
            flock7 += regionl7[i].transform.position;
        }
        detach7.transform.position = flock7 / (regionl7.Count);*/


    }

    // Update is called once per frame
    void Update()
    {
        disMA = 0;
        for (int i = 0; i < detach.Length; i++)
        {
            detach[i].transform.position = Vector3.Lerp(detach[i].transform.position, poses[i], Time.deltaTime);
            float disM0 = Vector3.Distance(detach[i].transform.position, poses[i]);
            disMA+= disM0;
            if (disM0 < 0.6f)
            {
                detach[i].transform.position = poses[i];
            }
        }

        if (disMA<=0)
        {
            insFlo.enabled = true;

            foreach (GameObject item in detach)
            {
                SetUnit[] sus = item.GetComponentsInChildren<SetUnit>();
                if (sus.Length == 0) { continue; }
                foreach (SetUnit su in sus)
                {
                    su.isBusy = false;
                }
            }
            bm.guard1 = false;
            this.gameObject.SetActive(false);
        }


    }
}

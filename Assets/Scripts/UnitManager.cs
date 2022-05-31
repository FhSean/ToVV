using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private int numberFactor;
    private NeighboursCount nb;
    private DetectClearFace dcf1;
    private DetectClearFace dcf2;
    [SerializeField]
    private Material[] lcMat;

    private MeshRenderer[] core;
    // Start is called before the first frame update
    void Start()
    {
        
        nb = this.transform.parent.GetComponentInChildren<NeighboursCount>();
        dcf1 = this.transform.parent.GetChild(2).GetChild(0).GetComponent<DetectClearFace>();
        dcf2 = this.transform.parent.GetChild(2).GetChild(10).GetComponent<DetectClearFace>();
        core = this.transform.GetChild(2).GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        numberFactor = nb.numberOfNeighbours;
        //Debug.Log(dcf1.clearFace);
        if (dcf1.clearFace==true&&dcf2.clearFace==true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }


        if (numberFactor >=0 && numberFactor < 2)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[0];
            }
            this.gameObject.tag = "Type00";
        }
        else if (numberFactor >= 2 && numberFactor < 3)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[1];
            }
            this.gameObject.tag = "Type01";
        }
        else if (numberFactor >=3  && numberFactor < 4)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[2];
            }
            this.gameObject.tag = "Type02";
        }
        else if (numberFactor >= 4)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[3];
            }
            this.gameObject.tag = "Type03";
        }
        
    }
}

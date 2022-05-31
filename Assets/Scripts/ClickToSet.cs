using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSet : MonoBehaviour
{
    public GameObject Unit;
    [SerializeField]
    private GameObject boundary;
    [SerializeField]
    private GameObject _canvas;
    private RectTransform rect;
    private float scale;
    [SerializeField]
    private LayerMask hitMask;
    private BoundaryManager bm;

    // Start is called before the first frame update
    void Start()
    {
        rect = _canvas.GetComponent<RectTransform>();
        bm = boundary.GetComponent<BoundaryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(rect.position);
        RaycastHit hit;
        //int octLayerMask = 1;
        Vector3 pos =Vector3.zero;

        if (Input.GetButtonDown("South"))
        {
            
            if (Physics.Raycast(ray,out hit,Mathf.Infinity,hitMask))
            {
                //Debug.Log(hit.transform.gameObject.tag);
                /*if (Mathf.Abs(hit.normal.y) <= 0.1f)
                {
                    //Debug.Log("what");
                    scale = 0.58f;
                }
                else if (hit.normal.x == 0f &&hit.normal.z == 0f)
                {
                    scale = 0.58f;
                }
                else
                {
                    scale = 0.5023f;
                }*/
                    //Debug.Log("South");
                if (hit.transform.parent.tag=="UnitHit")
                {
                    bm.clickCount++;
                    if (hit.transform.name.Contains("Square"))
                    {
                        scale = 0.58f;
                    }
                    if (hit.transform.name.Contains("Hexagon"))
                    {
                        scale = 0.5023f;
                    }
                    pos = hit.transform.position+hit.normal*scale;
                    //Debug.Log(hit.normal.y);
                    //Quaternion rot = Quaternion.identity;
                    GameObject go = Instantiate(Unit, pos, Quaternion.identity);
                    //unit form&material manager
                    go.transform.GetChild(0).GetComponent<UnitManager>().enabled = true;
                    //animation
                    go.transform.GetChild(1).gameObject.SetActive(true);


                }
            }
        }
    }
}

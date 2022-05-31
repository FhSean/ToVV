using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoundaryManager : MonoBehaviour
{

    public int unitsCount;
    public int scaleFactor;
    public int clickCount;
    public bool reachLimit = false;
    public bool reachLimit1=false;
    public bool reachLimit2=false;
    public bool guard1=true;
    public GameObject[] units;
    [SerializeField]
    private GameObject NM1;
    [SerializeField]
    private GameObject NM2;
    private FunctionManager fm;
    private InstantiateFloatage instantiateFloatage;

    // Start is called before the first frame update
    void Start()
    {

        fm = GameObject.FindGameObjectWithTag("FunctionManager").GetComponent<FunctionManager>();
        instantiateFloatage = this.GetComponent<InstantiateFloatage>();

    }

    // Update is called once per frame
    void Update()
    {

        units = GameObject.FindGameObjectsWithTag("Unit");
        unitsCount = units.Length;
        reachLimit=fm.testPerfectSquare(unitsCount,out int root);
        scaleFactor = (int)Mathf.Pow(unitsCount, (1f / 3f))/2;
        if (scaleFactor >= 2)
        {
            transform.localScale = new Vector3(10, 10, 10) * scaleFactor;
        }
        if (scaleFactor == 2)
        {
            reachLimit1 = true;
        }
        if (reachLimit1&&guard1)
        {
            NM1.SetActive(true);
            //instantiateFloatage.enabled = false;
            reachLimit1 = false;
        }
        if (reachLimit&&scaleFactor>=3)
        {
            reachLimit2 = true;
        }
        if (reachLimit2)
        {
            NM2.SetActive(true);
            //Debug.Log("active");
            //instantiateFloatage.enabled = false;
        }
        /*int scaleFactor = unitsCount / 15;
        if (scaleFactor>=2)
        {
            transform.localScale= new Vector3(10, 10, 10) * scaleFactor;
        }*/

    }

    
}

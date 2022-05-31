using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateFloatage : MonoBehaviour
{
    private float coordX;
    private float coordY;
    private float coordZ;
    private float makeFactor;
    public float makeSpeed=1f;
    [SerializeField]
    private float MakeRate=1f;
    private float _lastMake;
    private int _makeCount;
    private BoundaryManager bm;

    [SerializeField]
    private GameObject flotage;

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        makeFactor = this.GetComponent<BoundaryManager>().scaleFactor;
        if (makeFactor<1)
        {
            makeFactor = 1;
        }
        makeSpeed = slider.value;
        _lastMake += Time.deltaTime * makeSpeed*makeFactor;
        if (_lastMake > MakeRate)
        {
            coordY = Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2);
            coordZ= Random.Range(-this.transform.localScale.z / 2, this.transform.localScale.z / 2);
            _lastMake = 0f; 
            _makeCount++; 
            //Debug.Log("Make");
            GameObject go = Instantiate(flotage, new Vector3(this.transform.localScale.x / 2, coordY, coordZ), Quaternion.identity);
            /*Bus mu = go.GetComponent<Bus>();
            mu.Target = Target1;*/
            /*if (_makeCount>=1)
            {
                this.enabled = false;
            }*/
        }
        
    }
}

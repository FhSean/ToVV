using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Type00 : MonoBehaviour
{
    [SerializeField]
    private GameObject boundary;
    private string typeCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitTypeCount utc = boundary.GetComponent<UnitTypeCount>();
        typeCount = utc.n00.ToString();
        Text text = this.GetComponent<Text>();
        text.text = typeCount;
    }
}

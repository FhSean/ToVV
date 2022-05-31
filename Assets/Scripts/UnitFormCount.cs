using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFormCount : MonoBehaviour
{
    public int f00;
    public int f01;
    public int f02;
    private BoundaryManager bm;
    [SerializeField]
    private GameObject Form00;
    private Text text00;
    [SerializeField]
    private GameObject Form01;
    private Text text01;
    [SerializeField]
    private GameObject Form02;
    private Text text02;
    // Start is called before the first frame update
    void Start()
    {
        bm = this.GetComponent<BoundaryManager>();
        text00 = Form00.GetComponent<Text>();
        text01 = Form01.GetComponent<Text>();
        text02 = Form02.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] wings = GameObject.FindGameObjectsWithTag("Wing");
        f00 = bm.clickCount;
        f01 = bm.unitsCount - f00-1;
        f02 = wings.Length;

        text00.text = f00.ToString();
        text01.text = f01.ToString();
        text02.text = f02.ToString();
    }
}

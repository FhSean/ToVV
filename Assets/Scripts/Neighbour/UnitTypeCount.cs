using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitTypeCount : MonoBehaviour
{
    public int n00;
    public int n01;
    public int n02;
    public int n03;
    [SerializeField]
    private GameObject Type00;
    private Text text00;
    [SerializeField]
    private GameObject Type01;
    private Text text01;
    [SerializeField]
    private GameObject Type02;
    private Text text02;
    [SerializeField]
    private GameObject Type03;
    private Text text03;

    // Start is called before the first frame update
    void Start()
    {
        text00 = Type00.GetComponent<Text>();
        text01 = Type01.GetComponent<Text>();
        text02 = Type02.GetComponent<Text>();
        text03 = Type03.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] n00s = GameObject.FindGameObjectsWithTag("Type00");
        GameObject[] n01s = GameObject.FindGameObjectsWithTag("Type01");
        GameObject[] n02s = GameObject.FindGameObjectsWithTag("Type02");
        GameObject[] n03s = GameObject.FindGameObjectsWithTag("Type03");
        n00 = n00s.Length;
        n01 = n01s.Length;
        n02 = n02s.Length;
        n03 = n03s.Length;

        text00.text = n00.ToString();
        text01.text = n01.ToString();
        text02.text = n02.ToString();
        text03.text = n03.ToString();

    }
}

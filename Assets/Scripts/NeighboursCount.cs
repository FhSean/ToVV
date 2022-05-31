using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursCount : MonoBehaviour
{
    public int numberOfNeighbours;
    private GameObject neighbour;
    //private List<GameObject> neighbourList=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        NeighbourDetection[] neighbours = this.GetComponentsInChildren<NeighbourDetection>();
        numberOfNeighbours = neighbours.Length;
        //Debug.Log(neighbours.Length);
    }

   
}

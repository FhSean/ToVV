using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourDetector : MonoBehaviour
{
    private GameObject neighbour;
    // Start is called before the first frame update
    void Start()
    {
        neighbour = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        neighbour.SetActive(true);
    }
}

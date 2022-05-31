using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClearFace : MonoBehaviour
{
    public bool clearFace = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        clearFace = false;
    }

    private void OnTriggerExit(Collider other)
    {
        clearFace = true;
    }
}

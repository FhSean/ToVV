using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIn : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }
    }
}

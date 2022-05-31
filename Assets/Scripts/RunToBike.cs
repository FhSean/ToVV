using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToBike : MonoBehaviour
{
    public GameObject bikeman;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }
        bikeman.SetActive(true);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetOnBike : MonoBehaviour
{
    public string[] TargetTypes = new string[] { "BIKE" };

    [HideInInspector]
    public NavMeshAgent Agent;

    public GameObject[] Prefabs;

    private GameObject _athleteWithBike;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        //if (col.tag != "Agent") { return; }
        Debug.Log("Hit");
        //GameObject prefab = Prefabs[Random.Range(0, Prefabs.Length)]; //random prefab for man and woman
        //_athleteWithBike = Instantiate(prefab, this.transform.position, Quaternion.identity);
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }
}
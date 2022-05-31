using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory01 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _Prefabs;

    private GameObject _Prefab;
    private Rigidbody _preRB;
    private int _makeCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("South"))
        {
            int rnd = Random.Range(0, _Prefabs.Length);
            _Prefab = _Prefabs[rnd];
            Instantiate(_Prefab, this.transform.position, Quaternion.identity);
            _preRB = _Prefab.GetComponent<Rigidbody>();
            _preRB.AddForce(Vector3.up * 1000 + Vector3.forward * 1000);
            _makeCount++;
        }


    }
}

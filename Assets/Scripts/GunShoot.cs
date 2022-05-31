using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _Prefabs;

    private Vector3 _dir;
    private GameObject _Prefab;
    private Rigidbody _preRB;
    private int _makeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.rotation);
        _dir = transform.forward;
        Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
        if (Input.GetButtonDown("South"))
        {
            int rnd = Random.Range(0, _Prefabs.Length);
            _Prefab = _Prefabs[rnd];
            GameObject tempP=Instantiate(_Prefab, this.transform.position, Quaternion.identity);
            _preRB = tempP.GetComponent<Rigidbody>();
            //_preRB.velocity = _dir * 5f;
            Debug.Log(_dir);
            _preRB.AddForce(_dir * 500,ForceMode.Impulse);
            _makeCount++;
            
        }
    }
}

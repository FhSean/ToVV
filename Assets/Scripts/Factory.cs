using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject Prefab;

    public GameObject Target;

    public float MakeRate = 2.0f;

    private float _lastMake = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        _lastMake += Time.deltaTime; //same to _lastMake = _lastMake + Time.deltaTime; //keep to track time;
        if (_lastMake > MakeRate)
        {
            Debug.Log("Make"); //will happen every two seconds;
            _lastMake = 0;

            GameObject go = Instantiate(Prefab, this.transform.position, Quaternion.identity); //Instantiste = Clone, Quanternion.identity = keep origin;
            MobileUnit mu = go.GetComponent<MobileUnit>(); //use the MobileUnit script for go
            mu.Target = Target;
        }
    }
}
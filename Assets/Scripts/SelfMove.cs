using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfMove : MonoBehaviour
{
    private float speed;
    private Slider slider;
    public GameObject boundaryBox;
    // Start is called before the first frame update
    void Start()
    {
        boundaryBox = GameObject.FindGameObjectWithTag("BoundaryBox");
        slider = FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = slider.value;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //Debug.Log(this.transform.position.x);
        if (this.transform.position.x<=(-boundaryBox.transform.localScale.x/2f))
        {
            Destroy(this.gameObject);
        }
    }
}

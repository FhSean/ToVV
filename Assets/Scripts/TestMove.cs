using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    //public float speed;
    public GameObject yes;

    [SerializeField]
    private Animator anim;

    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        nav = this.GetComponent<NavMeshAgent>();
        nav.SetDestination(yes.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsWalking", nav.velocity.magnitude > 0.01f);
        float f = nav.velocity.magnitude;
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

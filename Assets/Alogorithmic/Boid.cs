using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public GameObject[] gos;
    public FlockManager Manager;
    private Rigidbody _rb;
    private float Speed;
    private bool turning = false;

    // Start is called before the first frame update
    private void Start()
    {
        Speed = Random.Range(Manager.MinSpeed, Manager.MaxSpeed);
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void BoidUpdate()
    {
        //step9
        Bounds b = new Bounds(Manager.transform.position, Manager.Limits * 2);
        RaycastHit hit;
        Vector3 direction = Manager.transform.position - transform.position;
        //Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
        if (!b.Contains(this.transform.position))
        {
            turning = true;
        }
        else if (Physics.Raycast(this.transform.position,this.transform.forward,out hit))
        {
            turning = true;
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        }
        else
        {
            turning = false;
        }

        //if turning is ture
        if(turning)
        {
            Quaternion quat = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                    this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, Time.deltaTime * Speed);
            return; // exit, end function

        }

        //random speed
        if(Random.Range(0,100)<10)
            Speed = Random.Range(Manager.MinSpeed, Manager.MaxSpeed);
        if (Random.Range(0, 100) > 20)
        {
            transform.Translate(0, 0, Time.deltaTime * Speed);
            return;
        }

            GameObject[] boids = Manager.boids;

        Vector3 groupCenter = Vector3.zero; //1.
        float groupSpeed = 0.01f;
        int groupsize = 0; //group within distance
        Vector3 avoid = Vector3.zero;//3.

        //update flock calculations
        //1.Move toward average position of the group.
        //2.Align with the average heading/direction of the group.
        //3.Avoid crowing other flock members
        foreach (GameObject go in boids)
        {
            if(go == this.gameObject) { continue; }//skip, next"guard statement"

            float distance = Vector3.Distance(go.transform.position, this.transform.position);//3.
            if(distance > Manager.NeighborDistance) { continue; }

            groupCenter += go.transform.position; //1.
            groupsize++;//1.

            if(distance < 1.0f)
            {
                avoid += (this.transform.position - go.transform.position);//move in the opposite direction
            }

            Boid boidscript = go.GetComponent<Boid>();
            groupSpeed += boidscript.Speed;
        }

        if(groupsize > 0)
        {
            groupCenter = groupCenter / groupsize + (Manager.GoalPos - this.transform.position); // average of all boid vectors
            groupSpeed = groupSpeed / groupsize; // average of all boid speeds

            direction = (groupCenter + avoid) - this.transform.position;
            if(direction != Vector3.zero)
            {
                Quaternion quat = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);
            }
        }

        transform.Translate(0, 0, Time.deltaTime * Speed);
    }

    private void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject item in gos)
        {
            Vector3 v = item.transform.position - this.transform.position;
            if (v.magnitude<=2f)
            {
                Vector3 _dir= item.transform.position - this.transform.position;
                Vector3 _fd = _dir.normalized;
                _rb.AddForce(_fd * 0.5f, ForceMode.Impulse);
            }
        }
    }
}

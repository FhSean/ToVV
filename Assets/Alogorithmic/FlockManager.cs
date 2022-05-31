using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject BoidPrefab;
    public int BoidCount = 20;
    public Vector3 Limits = new Vector3(5, 5, 5);

    [HideInInspector]
    public GameObject[] boids;

    [Header("Boid Settings")]
    [Range(0.0f, 5.0f)]
    public float MinSpeed;

    [Range(0.0f, 10.0f)]
    public float MaxSpeed;

    [Range(1.0f, 10.0f)]
    public float NeighborDistance;

    [Range(0.0f, 5.0f)]
    public float RotationSpeed;

    public Vector3 GoalPos;

    // Start is called before the first frame update
    private void Start()
    {
        boids = new GameObject[BoidCount];
        for(int i = 0; i < BoidCount; i++)
        {
            float x = Random.Range(-Limits.x, Limits.x);
            float y = Random.Range(-Limits.y, Limits.y);
            float z = Random.Range(-Limits.z, Limits.z);
            Vector3 pos = this.transform.position + new Vector3(x, y, z);

            boids[i] = Instantiate(BoidPrefab,pos,Quaternion.identity);

            boids[i].GetComponent<Boid>().Manager = this;
        }

        GoalPos = this.transform.position; // step5
    }

    private void Update()
    {
        //GoalPos = this.transform.position;
        if(Input.GetButtonDown("North"))
        {
            float x = Random.Range(-Limits.x, Limits.x);
            float y = Random.Range(-Limits.y, Limits.y);
            float z = Random.Range(-Limits.z, Limits.z);
            GoalPos = this.transform.position + new Vector3(x, y, z);
        }

        for (int i = 0; i < BoidCount; i++)
        {
            boids[i].GetComponent<Boid>().BoidUpdate();
        }
    }
}

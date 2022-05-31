using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathChange : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
            Debug.Log("Space Pressed " + agents.Length);
            foreach (GameObject Agent in agents)
            {
                if (Agent.name.Contains("AGENT"))
                {
                    NavMeshAgent nav = Agent.GetComponent<NavMeshAgent>();
                    if (nav == null) { continue; }
                    //nav.areaMask = NavMesh.GetAreaFromName("Skypath");
                    //nav.areaMask |= (1 << LayerMask.NameToLayer("Skypath"));
                    nav.areaMask = NavMesh.AllAreas;
                    Debug.Log("Area Mask Changed");
                }
            }
        }
    }
}
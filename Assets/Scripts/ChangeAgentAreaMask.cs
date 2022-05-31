using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentAreaMask : MonoBehaviour
{
    private const string _agentTag = "Agent";
    private const string _agentName = "PERSON";
    private bool _originalArea = true;

    private const string _athleteTag = "Athlete";
    private const string _athleteName = "ATHLETE";
    private bool _athleteoriArea = false;

    private const string _areaStreet = "PATH";

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            GameObject[] agents = GameObject.FindGameObjectsWithTag(_agentTag);//object-s-
            GameObject[] athletes = GameObject.FindGameObjectsWithTag(_athleteTag);

            //update each agent
            foreach (GameObject agent in agents)
            {
                //if (agent.name != _agentName) { continue; } //if agent name is wrong, skip(because when instantiate in runtime there will be num after agent)
                if (!agent.name.Contains(_agentName)) { continue; }//but all the objects with agents may use this script(like BigAgent)
                NavMeshAgent nma = agent.GetComponent<NavMeshAgent>();
                if (nma == null) { continue; }//if NavMeshAgent component doesn't exist, skip
                int areaMask = nma.areaMask;

                //update area mask
                if (_originalArea)
                {
                    //if we want to update areas
                    areaMask += 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                else
                {
                    areaMask -= 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                nma.areaMask = areaMask;
                nma.ResetPath(); //changing areamask makes the path stale, so we have to reset(keeps same target)
            }

            foreach (GameObject athlete in athletes)
            {
                //if (athlete.name != _athleteName) { continue; }
                if (!athlete.name.Contains(_athleteName)) { continue; }
                NavMeshAgent nmath = athlete.GetComponent<NavMeshAgent>();
                if (nmath == null) { continue; }
                int athareaMask = nmath.areaMask;

                if (_athleteoriArea)
                {
                    athareaMask += 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                else
                {
                    athareaMask -= 1 << NavMesh.GetAreaFromName(_areaStreet);
                }
                nmath.areaMask = athareaMask;
                nmath.ResetPath();
            }
            //toggel original area status
            _originalArea = !_originalArea;
        }
    }
}
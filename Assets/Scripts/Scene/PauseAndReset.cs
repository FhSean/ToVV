using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndReset : MonoBehaviour
{
    [SerializeField]
    private GameObject boundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("ClickTest", LoadSceneMode.Single);
        }
        if (Input.GetButtonDown("Select"))
        {
            boundary.GetComponent<InstantiateFloatage>().enabled = false;
        }
    }
}

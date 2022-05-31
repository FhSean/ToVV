using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera00;
    [SerializeField]
    private GameObject Camera01;
    [SerializeField]
    private GameObject Camera02;

    private int cameraIndex=0;
    private RectTransform rt;
    [SerializeField]
    private float x0;
    [SerializeField]
    private float x1;
    [SerializeField]
    private float x2;
    [SerializeField]
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LeftButton"))
        {
            cameraIndex--;
            if (cameraIndex<=0)
            {
                cameraIndex = 0;
            }
        }
        if (Input.GetButtonDown("RightButton"))
        {
            cameraIndex++;
            if (cameraIndex >= 2)
            {
                cameraIndex = 2;
            }
        }

        if (cameraIndex==0)
        {
            Camera00.SetActive(true);
            Camera01.SetActive(false);
            Camera02.SetActive(false);
            rt.localPosition = new Vector3(x0, y,0);
        }
        else if (cameraIndex == 1)
        {
            Camera00.SetActive(false);
            Camera01.SetActive(true);
            Camera02.SetActive(false);
            rt.localPosition = new Vector3(x1, y,0);
        }
        else if (cameraIndex == 2)
        {
            Camera00.SetActive(false);
            Camera01.SetActive(false);
            Camera02.SetActive(true);
            rt.localPosition = new Vector3(x2, y,0);
        }
    }
}

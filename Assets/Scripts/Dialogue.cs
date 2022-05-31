using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject Balloon;

    //public string Text;
    [TextArea(3, 10)]
    public string Text;

    private GameObject _curBalloon;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("in");
        if (col.tag != "Player") { return; }

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) { return; }

        _curBalloon = Instantiate(Balloon);
        _curBalloon.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2.0f, 15);
        _curBalloon.GetComponent<Text>().text = Text;
        _curBalloon.transform.parent = canvas.transform;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag != "Player") { return; }
        if (_curBalloon == null) { return; }
        Destroy(_curBalloon);
    }
}
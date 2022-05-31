using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMover : MonoBehaviour
{
    // By Simon Willcock
    // This is a basic C# Keyboard & Mouse control script for UNITY (tested on 2020.3.25f)

    // To use simply add it to your camera asset.
    // You can then set the amount of movement performed using the following variables -

    // 	keyboardMoveSpeed = 25.0f;
    // 	keyboardTurnSpeed = 5.0f;

    // 	mouseMoveSpeed = 50.0f;
    // 	mouseScrollSpeed = 20.0f;
    // 	mouseTurnSpeed = 4.0f;

    // 	minTurnAngle = -90.0f;
    // 	maxTurnAngle = 90.0f;

    // For keyboard support, it implements the following
    // 1) WASD keys with the up and down arrow keys for movement in the X,Y,Z-axis 
    // 2) Left and right arrows rotate in the Y (or left to right)

    // For the mouse support, it implements the following 
    // 1) When no mouse button is pressed it will DO NOTHING.
    // 2) Left mouse button pressed and the mouse moved for will rotate the camera.
    // 3) Right button pressed and the mouse moved will move the camera in X and Y-axis.
    // 4) Both buttons pressed causes movement in the Z-axis (or zooming in and out), the amount of movement is based on the Y movement of the mouse
    // 5) Scroll wheel pressed causes also causes zooming in and out on the Z-axis


    public float keyboardMoveSpeed = 25.0f;
    public float keyboardTurnSpeed = 5.0f;


    private float rotX;

    void Update()
    {
        KeyboardMovement();
    }


    void KeyboardMovement()
    {

        // -------------------------------------------------------------------------------------------------
        // Handle movement using the WASD keys

        // Detect any key presses 
        Vector3 pos = transform.position;
        if (Input.GetKey("a"))
        {
            pos.z += keyboardMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.z -= keyboardMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            pos.x += keyboardMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.x -= keyboardMoveSpeed * Time.deltaTime;
        }

        // This is an alternative way of handling the WASD keys

        //  Vector3 dir = new Vector3(0, 0, 0);
        //  dir.x = Input.GetAxis("Horizontal");
        //  dir.z = Input.GetAxis("Vertical");
        //  transform.Translate(dir * keyboardMoveSpeed * Time.deltaTime);

        // Handle up and down arrows
        // Comment these lines out if you want to use the up and down arrow keys for rotation instead 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += keyboardMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= keyboardMoveSpeed * Time.deltaTime;
        }

        // Set the position
        transform.position = pos;

        // -------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------
        // Handle the  arrow keys for rotation

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, keyboardTurnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -keyboardTurnSpeed, 0);
        }

        // if you want to use the up and down arrow keys for rotation instead  then uncomment these lines and
        // comment out the up and down arrow keys above
        // 
        //  if (Input.GetKey(KeyCode.UpArrow))
        //  {
        //        transform.Rotate(keyboardTurnSpeed, 0, 0);
        //  }

        //  if (Input.GetKey(KeyCode.DownArrow))
        //  {
        //        transform.Rotate(-keyboardTurnSpeed, 0, 0);
        //  }

        // -------------------------------------------------------------------------------------------------

    }
}
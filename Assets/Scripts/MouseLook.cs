using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseLook : MonoBehaviour
{
    [Flags]
    public enum RotationDirection
    {
        None,
        Horizontal = (1 << 0),
        Vertical = (1 << 1)
    }

    [Tooltip("Which directions thsi object can rotate")]
    [SerializeField]
    private RotationDirection rotationDirections;
    [Tooltip("A multiplier to the input. Describes the maximum speed in degrees / second. To flip vertical rotation, set Y to a negative value")]
    [SerializeField]
    private Vector2 sensitivity;
    [Tooltip("The rotation acceleration, in degrees / second")]
    [SerializeField]
    private Vector2 acceleration;
    [Tooltip("The maximum angle from the horizon the player can rotate, in degrees")]
    [SerializeField]
    private float maxVerticalAngleFromHorizon;
    [Tooltip("The period to wait until resetting the imput value. Set this as low as possible, without encountering stuttering")]
    [SerializeField]
    private float inputLagPeriod;

    private Vector2 rotation;//Current rotation, in degrees
    private Vector2 velocity;//Current rotation velocity, in degrees
    private Vector2 lastInputEvent;//The last received non-zero input value
    private float inputLagTimer;//The time since the last received non-zero input value
    

    //When this component is enabled, we need to reset the state and figure out the current rotation
    private void OnEnable()
    {
        //Reset the state
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        //Calculate the current rotation by getting the gameObject's local euler angles
        Vector3 euler = transform.localEulerAngles;

        //Euler angles range from (0, 360), but we want (-180, 180)
        if (euler.x >= 180)
        {
            euler.x -= 360;
        }
        euler.x = ClampVerticalAngle(euler.x);
        //Set the angles here to clamp the current rotation
        transform.localEulerAngles = euler;
        //Rotation is stores as (horizontal, vertical), which corresponds to the euler angles around the y axis and the x axis
        rotation = new Vector2(euler.y, euler.x);
    }
    float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }
    Vector2 GetInut()
    {
        //Add to the lag timer
        inputLagTimer += Time.deltaTime;
        Vector2 mouseInput = new Vector2(Input.GetAxis("RightJoyX"), Input.GetAxis("RightJoyY"));
        //Debug.Log(mouseInput);
        if ((Mathf.Approximately(0, mouseInput.x) && Mathf.Approximately(0, mouseInput.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = mouseInput;
            inputLagTimer = 0;
        }
        return lastInputEvent;
    }
/*    // Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //The wanted velocity is the current input scaled by the sensitivity
        //This is also the maximum velocity
        Vector2 wantedVelocity = GetInut() * sensitivity;

        //Zero out the wanted velocity if this controller does not rotate in that direction
        if ((rotationDirections & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0;
        }
        if ((rotationDirections & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0;
        }

        //Calculate new rotation
        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime));
        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);

        //Convert the rotation to euler angles
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);

        
    }
}

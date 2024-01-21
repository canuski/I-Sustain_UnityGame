using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft; // serializefields for every wheel

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform; // transform objects representing each wheel


    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate() // physiscs related calculations
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical"); // returns -1 or 1 depending on player's vertical movement

        if (Input.GetKey(KeyCode.Space)) // when spacebar is pressed apply breakingforce
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration; // update all the wheels

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce; // update all the wheels

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal"); // returns -1 or 1 depending on player's horizontal movement
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle; // update front wheels for turning

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform); // call UpdateWheel method for each wheel


    }

    void UpdateWheel(WheelCollider col, Transform trans) {
        Vector3 position; // declare position of type Vector3 which represents coordinates
        Quaternion rotation;// declare rotation of type quaternion which represents rotations
        col.GetWorldPose(out position, out rotation); // retrieves world position and rotation

        trans.position = position;
        trans.rotation = rotation; // assigns these
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Thruster[] thrusters;

    Transform myT;
    void Awake()
    {
        myT = transform;
    }


    void Update()
    {
        Thrust();
        Turn();
    }
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");//input * turn speed * Time.delta
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch, yaw, -roll);

    }

    void Thrust()
    {
        //als we start met thrusten roep thruster.actvivate, asl we stoppen doe Thruster.Activate(false) 

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * movmentSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (Thruster t in thrusters)
            {
                t.Activate();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            foreach (Thruster t in thrusters)
            {
                t.Activate(false);
            }
        }
    }
}
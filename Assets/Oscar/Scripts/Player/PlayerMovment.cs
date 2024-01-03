using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // instellingen
    [SerializeField] float movmentSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    // de thrusters hier in een arry toevoegen omdat we er meerdere hebben
    [SerializeField] Thruster[] thrusters;

    // cache de transform
    Transform myT;
    void Awake()
    {
        // cache de transform
        myT = transform;
    }


    void Update()
    {
        Thrust();
        Turn();
    }
    void Turn()
    {
        // draai speed x input x time.delta(zodat de fps ok blijft) 
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");//input * turn speed * Time.delta
        // pitch is voor op en neer
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        // roll is om te rollen
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        // de trasform waardes aanpassen naar dat, '-' weet ik niet waarom de controls inverted zijn
        myT.Rotate(-pitch, yaw, -roll);

    }

    void Thrust()
    {
        // als we beginnen met thrusten roepen we Thruster.Activate aan. Als je stoppen, doen we Thruster.Activate(false).

        // controleer of de vertical pos is in unity
        if (Input.GetAxis("Vertical") > 0)
        {
            // beweeg object vooruit op basis van de input en snelheid (movmentSpeed)
            transform.position += transform.forward * movmentSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }

        // als W is ingedrukt (vooruit)
        if (Input.GetKeyDown(KeyCode.W))
        {
            // activeer elke raket in de lijst van thrusters
            foreach (Thruster t in thrusters)
            {
                t.Activate();
            }
        }

        // check als w nog ingedrukt is
        else if (Input.GetKeyUp(KeyCode.W))
        {
            // deactiveer elke raket in de lijst van thrusters
            foreach (Thruster t in thrusters)
            {
                t.Activate(false);
            }
        }
    }
}
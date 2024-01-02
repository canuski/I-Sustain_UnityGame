using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deze componeten MOETEN er zijn (niet echt nodig maar wou testen)
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{

    [SerializeField] TrailRenderer tr;
    [SerializeField] Light thrusterLight;

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    private void Start()
    {
        tr.enabled = false;
        thrusterLight.enabled = false;
    }

    // dit zet de thrusters aan/uit
    // heb ik deze script wel nodig --> morgen nakijken
    public void Activate(bool activate=true)
    {
        if (activate)
        {
            tr.enabled = true;
            thrusterLight.enabled = true;
        }

        else
        {
            tr.enabled=false;
            thrusterLight.enabled=false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    Light thrusterLight;

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

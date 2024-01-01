using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpsidedown : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            Application.LoadLevel("Level_5");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckUpsidedown : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0) // use mathematical operation "dot product" to know if car is upside down
        {
            SceneManager.LoadScene("Level5"); 
        }

    }
}

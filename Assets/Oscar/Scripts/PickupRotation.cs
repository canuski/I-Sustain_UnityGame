using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotation : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // vector wordt rondgedraait tegen de aangegeven snelheid
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}

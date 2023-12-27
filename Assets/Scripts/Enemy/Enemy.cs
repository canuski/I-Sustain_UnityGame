using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.2f;

    [SerializeField] float rotatieOffset = 100f;

    Transform myT;
    Vector3 randomRotatie;


    void Awake()
    {
        myT = transform;
    }
    void Start()
    {
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        myT.localScale = scale;

        randomRotatie.x = Random.Range(-rotatieOffset, rotatieOffset);
        randomRotatie.y = Random.Range(-rotatieOffset, rotatieOffset);
        randomRotatie.z = Random.Range(-rotatieOffset, rotatieOffset);

    }
    
    void Update()
    {
        myT.Rotate(randomRotatie * Time.deltaTime);
    }

}
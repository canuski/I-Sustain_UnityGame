using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_cam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 5f, -10f);
    [SerializeField] float distanceDamp = 20f;
    // [SerializeField] float rotationDamp = 10f;

    Transform myT;

    public Vector3 velocity = Vector3.one;
    void Awake()
    {
        myT = transform; 
    }
    void LateUpdate()
    {
        smoothFollow();

    }

    void smoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;

        myT.LookAt(target,target.up);
    }

}

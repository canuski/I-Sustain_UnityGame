using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_cam : MonoBehaviour
{
    [SerializeField] Transform target; //player
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 5f, -10f); // default pos
    [SerializeField] float distanceDamp = 20f; // deze waarde om de smoothness in te stellen

    Transform myT; //om de trasform te cachen, beter voor performance tov da heel de tijd aanroepen 

    public Vector3 velocity = Vector3.one; //na vragen
    void Awake()
    {
        myT = transform; // transform cachen
    }
    // aangeroepen na de update van player zelf
    void LateUpdate()
    {
        smoothFollow();
    }

    void smoothFollow()
    {
        // toPos berekent de positie van de camera door de rotatie op te tellen bij 
        // de player zijn positie
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        // smoothdamp wordt gebruikt om zachtjes te gaan van de huidige pos naar de
        // gewilde pos
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        // de camera pos updaten naar de geinterpoleerde positie
        myT.position = curPos;
        // lookat gaat de camera altijd op het doel houden gericht
        myT.LookAt(target,target.up);
    }

}

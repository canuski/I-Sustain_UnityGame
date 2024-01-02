using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    // speler object hier plaasten
    [SerializeField] Transform player;
    // Late update gebeurd na de update, dit is goed voor cameras
    // zodat de player zeker zijn update al heeft uigevoerd
    private void LateUpdate()
    {
        // een nieuwe vector 3 aanmaken waar de x,y en z waardes hetzelfde als de speler
        // worden gezet
        Vector3 newPos = player.position;
        // y waarde van de nieuwe vector wordt gezet op de hoogte van het huidige object
        newPos.y=transform.position.y;
        // positie van het huidige object op hetgene van de player zetten
        transform.position=newPos;
    }
}

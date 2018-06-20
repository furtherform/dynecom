using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSyncCollision : MonoBehaviour {

    int objectsInZone = 0;

    void OnTriggerEnter(Collider other)
    {
        objectsInZone++;
        //Debug.Log("Enter, objects: " + objectsInZone);
    }

    void OnTriggerStay(Collider other)
    {
        // one wave has objects to render both sides -> 2 waves == 4 objects
        if (objectsInZone >= 4)
        {
            //Debug.Log("Breathe in sync");
            // do sync stuff
            // if player1 color/gradient is close to player2 color/gradient, then plane
        } 
    }

    void OnTriggerExit(Collider other)
    {
        objectsInZone--;
        //Debug.Log("Exit, objects: " + objectsInZone);
    }
}

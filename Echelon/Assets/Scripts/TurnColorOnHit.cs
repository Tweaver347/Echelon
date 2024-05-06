using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColorOnHit : MonoBehaviour
{
    public TrainingAreaObjectiveManger objectiveManager;
    void OnCollisionEnter(Collision collision)
    {   
        if(GetComponent<Renderer>().material.color != Color.red){
            objectiveManager.targetsHit++;
        }  
        GetComponent<Renderer>().material.color = Color.red; 
        // if material color is not red, add 1 to targets hit in objectiveManager
    }
}

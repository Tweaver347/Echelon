using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingAreaObjectiveManger : MonoBehaviour
{
    public bool missionComplete;
    public bool shoothouseComplete;
    public int targetsHit = 0;

    void Update(){
        if(shoothouseComplete && targetsHit >= 9){
            missionComplete = true;
        }
    }
}

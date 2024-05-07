using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTrigger : MonoBehaviour
{
    public Level1ObjectiveManger objMan;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) objMan.objectiveFoundFunction();
    }
}

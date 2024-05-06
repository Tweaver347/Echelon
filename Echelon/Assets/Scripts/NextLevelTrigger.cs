using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public TrainingAreaObjectiveManger objectiveManger;
    void OnTriggerEnter(Collider other){
        if(objectiveManger.missionComplete){
            Debug.Log("Next Level");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

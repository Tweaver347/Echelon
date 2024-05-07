using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        Debug.Log("Next Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

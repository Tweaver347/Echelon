using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StorySoFar : MonoBehaviour
{
   public void OnReturn(){
        SceneManager.LoadScene(0);
    }
}

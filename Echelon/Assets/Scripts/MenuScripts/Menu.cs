using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStartButton(){
        SceneManager.LoadScene(1);
    }
    public void OnControls(){
        SceneManager.LoadScene(3);
    }
    public void OnStorySoFar(){
        SceneManager.LoadScene(2);
    }
    public void OnEndButton(){
        Application.Quit();
    }
}

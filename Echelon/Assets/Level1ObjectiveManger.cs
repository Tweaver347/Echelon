using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Level1ObjectiveManger : MonoBehaviour
{
    public bool objectiveFound = false;
    public GameObject objectiveText;
    public GameObject newObjectiveText;
    public GameObject newObjective;

    public void objectiveFoundFunction(){
        objectiveFound = true;
        // set objective text to green
        objectiveText.GetComponent<TextMeshProUGUI>().color = Color.green;
        newObjectiveText.SetActive(true);
        newObjective.SetActive(true);
    } 
}

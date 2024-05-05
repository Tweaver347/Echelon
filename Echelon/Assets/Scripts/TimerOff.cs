using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerOff : MonoBehaviour
{
    public StartAndDisplayTimer timer;
    public TextMeshProUGUI lastTimeText;
    public GameObject textObject;
    void OnTriggerEnter(Collider other)
    {
        timer.timerIsActive = false;
        // Set the LastTimeText to the timer after it has stopped
        lastTimeText.text = timer.timerText.text;
    }
}

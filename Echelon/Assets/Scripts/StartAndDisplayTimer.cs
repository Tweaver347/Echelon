using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartAndDisplayTimer : MonoBehaviour
{
    public GameObject textObject;
    public TextMeshProUGUI timerText;  // Reference to the UI Text component
    private float startTime;  // Time when the timer was started
    public bool timerIsActive = false;  // Flag to control the timer status
    public string startTag = "Player";  // Tag to check for collision


    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00:00";  // Initialize the timer display
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsActive)
        {
            float t = Time.time - startTime;  // Calculate the time elapsed since start

            // Format the time to minutes:seconds:milliseconds
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((int)(t * 100) % 100).ToString("00");

            // Update the text component
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    // This method is called when your GameObject collides with another GameObject
    void OnTriggerEnter(Collider other)
    {
        if (!timerIsActive && other.gameObject.tag == startTag)  // Check if the timer is not already active
        {
            textObject.SetActive(true);
            
            startTime = Time.time;  // Record the start time
            timerIsActive = true;  // Activate the timer
        }
    }
}

using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TMP_Text countdownText;
    public float countdownTime = 300f; // Example countdown time in seconds
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;
        if (countdownTime < 0f)
        {
            countdownTime = 0f;
        }
        float minutes = Mathf.FloorToInt(countdownTime / 60); 
        float seconds = Mathf.FloorToInt(countdownTime % 60);

        // Formats the string to always display 2 digits for mins and secs (00:00)
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

using TMPro;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI zoneText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    public string zone = "No Zone";
    public float objectif = 40f;
    private bool isTimerStarted = false;
    [SerializeField]
    private float timeRemaining = 600f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        /* if(Vector3.Distance(Camera.main.transform.position,transform.position) < objectif)
          {
              Debug.Log(gameObject.name);
              t.text = zone;
          }*/
        if (isTimerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Reduce timeRemaining by deltaTime

                // Format timeRemaining into minutes and seconds
                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                // Update the UI Text element
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                // Time's up!
                timerText.text = "Time's Up! You lose.";
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Handheld.Vibrate();

        //check if the collider is the camera
        if (other.CompareTag("MainCamera"))
        {
            zoneText.text = zone;
            isTimerStarted = true;
        }
    }
  
    /* private void OnDrawGizmos()
     {
         Gizmos.DrawWireSphere(transform.position, objectif);
     }*/

}
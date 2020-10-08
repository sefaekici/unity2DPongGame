using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DelayedStartScr : MonoBehaviour
{

    
    public GameObject countDown,pausePanel;
    void Start()
    {
        StartCoroutine("StartDelay");
    }

   

    IEnumerator StartDelay()
    {
        
        countDown.gameObject.SetActive(true);

        Time.timeScale = 0;
       
        
        
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        if (pausePanel.active != true)
        {
     
            countDown.gameObject.SetActive(false);
            Time.timeScale = 1;
            
        }
        
        
    }
}

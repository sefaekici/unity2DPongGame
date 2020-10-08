using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gamePausePanel,countStart;
    public static bool oyunDurduMu = false;
    public void loadTheGame()
    {
        
        //sahne yükleme islemi.
        SceneManager.LoadScene("PongGame");
    }

    public void loadHomeMenu()
    {
        //sahne yükleme islemi.
        SceneManager.LoadScene("HomeMenu");
         
    }

    public void loadHowToPlay()
    {   
        //sahne yükleme islemi.
        SceneManager.LoadScene("NasilOynanir");
    }

    public void quitGame()
    {
        //uygulamanin kapatilmasini saglar.
        Application.Quit();
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        oyunDurduMu = true;
        gamePausePanel.SetActive(true);
        countStart.gameObject.SetActive(false);
    }

    public void playGameButton()
    {
        oyunDurduMu = false;
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Top : MonoBehaviour
{   

    //gerekli degisken tanimlamalari yapildi.
    public Rigidbody2D rb;
    public int skorPlayer1, skorPlayer2;
    public TextMeshProUGUI playerOneText, playerTwoText,winText;    
    public GameObject canvasObject,playerOne,playerTwo,delayTheTour;
    


    void Start()
    {
        skorPlayer1 = 0;
        skorPlayer2 = 0;

        int randomSayi =UnityEngine.Random.Range(0,2);
        //baslangicta topa rastgele bir konumda doğru kuvvet uygulayan fonksiyon.
        ilkBaslangicNoktasi(randomSayi);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameEndController();
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //player1 e ve player2 ye temasında uygulanacak kuvvetler belirlenmiştir.
        
        if (col.gameObject.tag == "Player1")
        {
            rb.velocity = new Vector2(12f, UnityEngine.Random.Range(-5f,2.5f));
            
        }
        else if (col.gameObject.tag == "Player2")
        {   
            rb.velocity = new Vector2(-12f, UnityEngine.Random.Range(-5f, 2.5f));
            
        }


         
            //rb.velociy.x x de gelen kuvvetin aynı şekilde uygulanmasini saglamaktadir.
        if (col.gameObject.tag == "UstDuvar")
        {
            
            
            rb.velocity = new Vector2(rb.velocity.x,-4f);
            
            
        }
        //rb.velociy.x x de gelen kuvvetin aynı şekilde uygulanmasini saglamaktadir.
        else if (col.gameObject.tag == "AltDuvar")
        {  
            rb.velocity = new Vector2(rb.velocity.x,4f);  
        }
        
        
        //gerekli skorlar arttirilmiştır.
        if (col.gameObject.tag == "SolDuvar")
        {   
            
            //skor arayüze aktarıldı.
            skorPlayer2++;
            playerTwoText.text = skorPlayer2.ToString();

            //topun pozisyonu sıfırlandı ve topa tekrardan kuvvet uygulandi.
            transform.position = new Vector2(0f, 0f);

            //3 saniye bekleme animasyonu başlatan fonksiyon.
            StartCoroutine("StartDelay");
            
            int randomSayi = UnityEngine.Random.Range(0, 2);
            sonrakiBaslangicNoktasi(randomSayi);

        }
        else if (col.gameObject.tag == "SagDuvar")
        {
            //skor arayüze aktarıldı.
            skorPlayer1++;
            playerOneText.text = skorPlayer1.ToString();

            //3 saniye bekleme animasyonu başlatan fonksiyon.
            StartCoroutine("StartDelay");

            //topun pozisyonu sıfırlandı ve topa tekrardan kuvvet uygulandi.
            transform.position = new Vector2(0f, 0f);
            int randomSayi = UnityEngine.Random.Range(0, 2);
            sonrakiBaslangicNoktasi(randomSayi);

        }


        //aşşağıda bulunan kodlar topun y ekseninde sürekli yukarı aşşağı gidip sıkışmasını engellemek amacıyla konulmuştur.
        //sıkışmanın nedeni topa x ekseninde bazı durumlarda kuvvet uygulanmamasıdır. Bu nedenle bu çözüm uygulanmıştır.

        //randomForce değişkeni topun sıkışmasını engellerken topun x de rastgele bir tarafa hareket etmesini sağlar.
        int randomForce = UnityEngine.Random.Range(0,4);
        if (randomForce == 0 || randomForce==1 || randomForce==2)
        {
            Vector2 direction = col.transform.position - transform.position;
            rb.AddForceAtPosition(new Vector2(direction.normalized.x + 30f, direction.normalized.y), col.contacts[0].point);
            rb.velocity = rb.velocity.normalized * 10;
        }
        else if (randomForce == 3)
        {
            Vector2 direction = col.transform.position - transform.position;
            rb.AddForceAtPosition(new Vector2(direction.normalized.x - 30f, direction.normalized.y), col.contacts[0].point);
            rb.velocity = rb.velocity.normalized * 10;
        }
        

    }


    //oyun basladiginda top random olarak bir playera hareket etmesi için yazılmış fonksiyon.
    void ilkBaslangicNoktasi(int number)
    {
        
        if (number == 0)
        {
            rb.velocity = new Vector2(-6f,0f);
        }
        else if (number == 1)
        {
            rb.velocity = new Vector2(6f,0f);
        }
    }

    void sonrakiBaslangicNoktasi(int number)
    {


        if (number == 0)
        {
           
            rb.velocity = new Vector2(-0.0001f, 0f);
            playerPositionReset();
        }
        else if (number == 1)
        {
            rb.velocity = new Vector2(0.0001f, 0f);
            playerPositionReset();
        }
    }

    void gameEndController()
    {
        if (skorPlayer1 == 3)
        {
            delayTheTourFalse();
            winText.text = "Player1 Kazandi";
            canvasObject.SetActive(true);
            Time.timeScale = 0;

        }
        else if (skorPlayer2 == 3)
        {
            delayTheTourFalse();
            winText.text = "Player2 Kazandi";
            canvasObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void oyunuYenidenBaslat()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Start();
    }

    void playerPositionReset()
    {
        playerOne.transform.position = new Vector2(-8.07f,0f);
        playerTwo.transform.position = new Vector2(8.07f,0f);
    }

    IEnumerator StartDelay()
    {
        delayTheTour.gameObject.SetActive(true);
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        delayTheTour.gameObject.SetActive(false);
        if (GameManager.oyunDurduMu == false)
        {
            Time.timeScale = 1;
        }
        

    }

    //oyunun sonunda animasyonun tekrardan gözükmesini engeller.
    void delayTheTourFalse()
    {
        delayTheTour.gameObject.SetActive(false);
    }

    


}

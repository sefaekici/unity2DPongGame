using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{


    private float hiz = 5f; 

    
    void Update()
    {
        clampThePlayerTwo();
        moveThePlayerTwo();
    }


    //oyunucunun hareket etmesini sağlayan fonksiyon.
    void moveThePlayerTwo()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, hiz * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -hiz * Time.deltaTime, 0f);
        }
    }


    //oyununcunun belirlenen sınırlar dışına çıkmamasını sağlayan kod.
    void clampThePlayerTwo()
    {
        
        float yPosition = Mathf.Clamp(transform.position.y, -2.5f, 2.5f);
        transform.position = new Vector2(transform.position.x, yPosition);
    }
}

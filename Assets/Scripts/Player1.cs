using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private float hiz = 5f;

    // Update is called once per frame
    void Update()
    {
        clampThePlayerOne();
        moveThePlayerOne();
    }


    //player1 için haraket komutları.
    void moveThePlayerOne()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, hiz * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -hiz * Time.deltaTime, 0f);
        }
    }


    //oyununcunun belirlenen sınırlar dışına çıkmamasını sağlayan kod.
    void clampThePlayerOne()
    {
        
        float yPosition=Mathf.Clamp(transform.position.y, -2.5f, 2.5f);
        transform.position = new Vector2(transform.position.x, yPosition);
    }
}

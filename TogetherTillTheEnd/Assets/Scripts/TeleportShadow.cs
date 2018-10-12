using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShadow : MonoBehaviour
{
    public GameObject PlayerTwo;

    int frames = 2;

    void Start ()
    {
        PlayerTwo = GameObject.Find("Player2");
    }

    void FixedUpdate()
    {
        while (false)
        {
            transform.Translate(Vector2.left * .2f);

        }
            
        PlayerTwo.transform.position = this.transform.position;
        Destroy(gameObject);
    }

}

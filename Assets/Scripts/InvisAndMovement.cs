using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisAndMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public Material black;
    public Material invis;

    float t;

    public static bool isInvis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            //t = 0;
            //sr.material = black;
            //isInvis = false;
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {      
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
        {
            t = 0;
            sr.material = black;
            isInvis = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            t = 0;
            sr.material = black;
            isInvis = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }

        if (t > 1)
        {
            sr.material = invis;
            isInvis = true;
        }

    }
}

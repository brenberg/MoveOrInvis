using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetect : MonoBehaviour
{
    bool goingRight;
    public float speed;
    SpriteRenderer sr;

    public Material yellow;
    public Material red;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(transform.position.x < 1.7 && goingRight == true)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 1.7 && goingRight == true)
        {
            goingRight = false;
        }

        if (transform.position.x > -2 && goingRight == false)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -2 && goingRight == false)
        {
            goingRight = true;
        }

        if(t >= 3)
        {
            sr.material = yellow;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(InvisAndMovement.isInvis == false)
        {
            t = 0;
            sr.material = red;
        }

        else
        {
            sr.material = yellow;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothArm : MonoBehaviour
{
    public GameObject signal;

    public Renderer signalRend;

    // Start is called before the first frame update
    void Start()
    {
        signalRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plank")
        {
            signalRend.enabled = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plank")
        {
            signalRend.enabled = false;
        }
    }
}

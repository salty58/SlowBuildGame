using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;

    float slothRun = 0.5f;

    Vector3 axis = new Vector3(0, 0, 1);
    Vector3 slothArmPos;

    bool armIsRotating = false;
    bool inPlankZone = false;
    bool plankInPlace = false;

    Rigidbody2D myRigidBody;

    public GameObject slothArm;
    public GameObject slothArmRotate;
    public GameObject plankZone;
    //public GameObject signal;

    //public Renderer signalRend;

    public BoxCollider2D armCol;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        //signalRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        slothArmPos = slothArmRotate.transform.position;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.D))
        {
            armIsRotating = true;
        }
        else
        {
            armIsRotating = false;
        }

        /*
        if(armIsRotating)
        {
            slothArm.transform.RotateAround(slothArmPos, axis, Time.deltaTime * -10f);
        }
        */

        if (inPlankZone)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //plankInPlace = true;
                Destroy(plankZone);
                Debug.Log("Die");
            }
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(slothRun, 0f);
        slothArm.transform.RotateAround(slothArmPos, axis, Time.deltaTime * -10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plank")
        {
            inPlankZone = true;
            plankZone = collision.gameObject;

        }

        /*
        if (plankInPlace)
        {
            Destroy(collision.gameObject);
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plank")
        {
            inPlankZone = false;
        }
    }
}

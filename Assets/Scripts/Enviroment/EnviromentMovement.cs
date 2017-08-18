using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    // Variables
    public float rotationSpeed = 20f;
    public float deceleration = 10f;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call deceleration and rotation
        Decelerate();
        Rotation();
    }


    void Decelerate()
    {
        // Activates deceleration
        rigid.velocity += -rigid.velocity * deceleration * Time.deltaTime;
    }

    void Rotation()
    {
        // If user presses D OR right arrow
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the environment right
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        // If user presses A OR left arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the environment left
            transform.Rotate(0, 0 - rotationSpeed * Time.deltaTime, 0);
        }
    }
}

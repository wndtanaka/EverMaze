using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovementYOnly : MonoBehaviour
{
    // Variables
    public float rotationSpeed = 20f;
    public float deceleration = 10f;
    float inputV;
    float inputH;
    const float yRot = 0;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Call deceleration and rotation
       
        Rotation();
        Decelerate();
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }


    void Decelerate()
    {
        // Activates deceleration
        rigid.velocity += -rigid.velocity * deceleration * Time.deltaTime;
    }

    void Rotation()
    {
        inputV = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        inputH = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(0, inputH, 0);
    }
}

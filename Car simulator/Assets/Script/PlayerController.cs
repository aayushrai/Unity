using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // private variable
    private float speed = 35.0f;
    private float turnSpeed = 35.0f;
    private float Horizontal;
    private float Vertical;

    void Update()
    {   
        // Inputs
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        // Forward and Backward control
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Vertical);

        // Turn right and left
        transform.Rotate(Vector3.up ,Time.deltaTime * turnSpeed * Horizontal);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System;
using System.Net;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // private variable
    private float speed = 35.0f;
    private float turnSpeed = 35.0f;
    private float Horizontal;
    private float Vertical;
    String control;
    //Socket
    Thread receiveThread; //1
    UdpClient client; //2
    int port; //3
    public GameObject Player; //4
    AudioSource jumpSound; //5
    bool jump; //6

    void Start()
    {
        port = 9999; //1 
        InitUDP(); //4 
    }

    private void InitUDP()
    {
        print("UDP Initialized");
        receiveThread = new Thread(new ThreadStart(ReceiveData)); 
        receiveThread.IsBackground = true; 
        receiveThread.Start();
    }

    // 4. Receive Data
    private void ReceiveData()
    {
        client = new UdpClient(port); 
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
                byte[] data = client.Receive(ref anyIP); 

                string text = Encoding.UTF8.GetString(data);
                print(">> " + text);
                control = text;
            }
            catch (Exception e)
            {
                print(e.ToString()); 
            }
        }
    }


    void Update()
    {
        // Inputs
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        // Forward and Backward control
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Vertical);

        // Turn right and left
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * Horizontal);
        if (control == "f")
        {
            print("F");
            transform.Translate(Vector3.forward * Time.deltaTime * 500);
        }
        if (control == "b")
        {
            print("B");
            transform.Translate(Vector3.forward * Time.deltaTime * -500);
        }
        control = "";

    }
}

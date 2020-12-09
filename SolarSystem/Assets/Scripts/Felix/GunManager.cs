using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    //Variables
    public float rotateValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimGun();
    }

    //Move & Aim Gun
    void AimGun()
    {
        if(Input.GetKey(KeyCode.W)) //Right
        {
            transform.Rotate(rotateValue, 0.0f, 0.0f, Space.Self);
        }
        else if(Input.GetKey(KeyCode.S)) //Left
        {
            transform.Rotate(-rotateValue, 0.0f, 0.0f, Space.Self);
        }
        else if(Input.GetKey(KeyCode.D)) //Up
        {
            transform.Rotate(0.0f, rotateValue, 0.0f, Space.Self);
        }
        else if(Input.GetKey(KeyCode.A)) //Down
        {
            transform.Rotate(0.0f, -rotateValue, 0.0f, Space.Self);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
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
        ShootGun();
    }

    //Move & Aim Gun
    void AimGun()
    {
        if (Input.GetKey(KeyCode.S)) //Up
        {
            transform.Rotate(rotateValue, 0.0f, 0.0f, Space.Self);
        }
        else if (Input.GetKey(KeyCode.W)) //Down
        {
            transform.Rotate(-rotateValue, 0.0f, 0.0f, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D)) //Right
        {
            transform.Rotate(0.0f, rotateValue, 0.0f, Space.Self);
        }
        else if (Input.GetKey(KeyCode.A)) //Left
        {
            transform.Rotate(0.0f, -rotateValue, 0.0f, Space.Self);
        }
    }

   //Shoot Gun
   void ShootGun()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse");
        }
    }
}

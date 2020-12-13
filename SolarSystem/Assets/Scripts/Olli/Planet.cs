using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public double distanceVal = 0.0, distSpeed = 0.0,
        angleVal = 0.0, angleSpeed = 0.0;
    public float gravitationalConstant = 20f, mass = 0f;

    public ForceGenerator2D forceGen;

    // Start is called before the first frame update
    void Start()
    {
        distanceVal = 1.496 * Mathf.Pow(10, 11);
        angleVal = Mathf.PI / 6;
        angleSpeed = 1.990986 * Mathf.Pow(10, -7);

        //forceGen = GetComponent<ForceGenerator2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float deg = (float)angleVal * Mathf.Rad2Deg;
        if (angleVal >= 360)
            angleVal = 0;
    }

    public void SetVariables(GameObject obj)
    {
        Particle2D info = obj.GetComponent<Particle2D>();
        info.speed = 10f;
        info.Acceleration = new Vector3(-10f, 0f, -10f);
        info.Velocity = obj.transform.forward * info.speed;
        info.DampingConstant = 0.99f;
        info.Mass = 1.25f;
    }

    public void CalcForce(Particle2D info) 
    {
        //float force = gravitationalConstant * (info.Mass * ;
    }

}

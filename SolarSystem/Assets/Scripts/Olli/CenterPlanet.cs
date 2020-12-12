using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPlanet : MonoBehaviour
{
    //public ForceGenerator2D forceGen;
    public float sunGravitationalConstant = 50f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVariables(GameObject obj)
    {
        Particle2D info = obj.GetComponent<Particle2D>();
        info.speed = 0f;
        info.Acceleration = Vector3.zero;
        info.Velocity = Vector3.zero;
        info.DampingConstant = 0.99f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    //Variables
    public GameObject sun;

    public float orbitSpeed;
    //public float gravity;

    /*Formula Notes
    Orbital Eccentricity Calculations
    0 - ciruclar // 1 - elliptical
    E = (a - p) / (a + p) // a - point of closest approach(aphelion), p - point of greatest distance(perihelion)*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Last Update so if the sun ever moves, it'll move after it's moved
    void LateUpdate()
    {
        Orbit();
    }

    void Orbit()
    {

    }
}

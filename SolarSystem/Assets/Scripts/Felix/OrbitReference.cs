using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitReference : MonoBehaviour
{
    //Variables
    public GameObject sun;
    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Use late update to make sure planet moves after sun has moved (if we add something like that)
    void LateUpdate()
    {
        Orbit();
    }

    //Orbit
    void Orbit()
    {
        if(sun != null)
        {
            //Make sure to keep orbit distance from sun
            transform.position = sun.transform.position + (transform.position - sun.transform.position).normalized * orbitDistance;
            transform.RotateAround(sun.transform.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
        }
    }
}

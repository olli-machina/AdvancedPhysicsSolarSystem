using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public double distanceVal = 0.0, distSpeed = 0.0,
        angleVal = 0.0, angleSpeed = 0.0;
    public double gravitationalConstant = 9.8;

    // Start is called before the first frame update
    void Start()
    {
        distanceVal = 1.496 * Mathf.Pow(10, 11);
        angleVal = Mathf.PI / 6;
        angleSpeed = 1.990986 * Mathf.Pow(10, -7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

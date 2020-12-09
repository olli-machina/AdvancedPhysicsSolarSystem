using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public double distanceVal = 0.0, distSpeed = 0.0,
        angleVal = 0.0, angleSpeed = 0.0;
    public double gravitationalConstant = 9.8;

    public ForceGenerator2D forceGen;

    // Start is called before the first frame update
    void Start()
    {
        distanceVal = 1.496 * Mathf.Pow(10, 11);
        angleVal = Mathf.PI / 6;
        angleSpeed = 1.990986 * Mathf.Pow(10, -7);

        forceGen = GetComponent<ForceGenerator2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVariables(GameObject obj)
    {
        Particle2D info = obj.GetComponent<Particle2D>();
        info.speed = 600f;
        info.Acceleration = new Vector3(0f, -20f, 0f);
        info.Velocity = obj.transform.forward * info.speed;
        info.DampingConstant = 0.99f;
    }

}

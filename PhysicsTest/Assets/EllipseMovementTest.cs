using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseMovementTest : MonoBehaviour
{
    //Variables
    public Transform sunLocation;
    public float gravity;
    public float speed;
    public float posX, posY;
    public float angle;

    public float planetMass;
    public float sunMass;
    public float gravitationalConstant;
    public float distance;
    public float force;

    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 accumulatedForces;
    public float dampingConstant;

    public float planetRadius; //Collision Radius

    // Start is called before the first frame update
    void Start()
    {
        velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Orbit();
    }

    //Force = (gravitational constant) * (mass1 * mass2 / distance^2)
    void Orbit()
    {
        distance = Mathf.Sqrt(Vector3.Distance(sunLocation.position, gameObject.transform.position));
        force = gravitationalConstant * ((planetMass * sunMass) / distance);
        transform.position = new Vector3((sunLocation.position.x + Mathf.Cos(angle) * force), (sunLocation.position.y + Mathf.Sin(angle) * force), 0f);
        angle = angle + Time.deltaTime * speed;

        if(angle >= 360)
        {
            angle = 0;
        }
    }

    void Integrator()
    {
        distance = Mathf.Sqrt(Vector3.Distance(sunLocation.position, gameObject.transform.position));
        force = gravitationalConstant * ((planetMass * sunMass) / distance);
        accumulatedForces.x += force * Time.deltaTime;
        accumulatedForces.y += force * Time.deltaTime;
        accumulatedForces.z += force * Time.deltaTime;

        transform.position += new Vector3((velocity.x / 200.0f), 0f, ((velocity.z / 200.0f) * Time.deltaTime));
        Vector3 resultingAcceleration = acceleration;

        resultingAcceleration += accumulatedForces * (planetMass / 1.0f);

        velocity += (resultingAcceleration * Time.deltaTime);
        float damping = Mathf.Pow(dampingConstant, Time.deltaTime);
        velocity *= damping;

        //Reset Accumulated Forces
        accumulatedForces = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void TutorialCode()
    {
        posX = sunLocation.position.x + Mathf.Cos(angle) * gravity;
        posY = sunLocation.position.y + Mathf.Sin(angle) * gravity / 2;
        transform.position = new Vector3(posX, posY, 0f);
        angle = angle + Time.deltaTime * speed;

        if (angle >= 360)
        {
            angle = 0;
        }
    }
}

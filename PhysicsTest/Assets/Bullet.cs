using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    public Vector3 mPoint;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 accumulatedForces;
    public float dampingConstant;
    public float mMagnitude;

    public GameObject planetLocation;
    public float gravity;
    public float speed;
    public float posX, posY;
    public float angle;

    public float bulletMass;
    public float planetMass;
    public float gravitationalConstant;
    public float distance;
    public float force;

    public GameObject[] activePlanets;
    public bool inPlanetRadius;

    // Start is called before the first frame update
    void Start()
    {
        inPlanetRadius = false;

        //Get all planets
        int i = 0;
        foreach(GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            activePlanets[i] = planet;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlanetRadius)
        {
            CheckIfInPlanetRadius();
        }
        else
        {
            Orbit();
        }
    }

    void CheckIfInPlanetRadius()
    {
        for(int i = 0; i < activePlanets.Length; i++)
        {
            Debug.Log("Check: " + i);
            if(Vector3.Distance(activePlanets[i].transform.position, transform.position) < activePlanets[i].GetComponent<EllipseMovementTest>().planetRadius)
            {
                planetMass = activePlanets[i].GetComponent<EllipseMovementTest>().planetMass;
                planetLocation = activePlanets[i];
                inPlanetRadius = true;
                break;
            }
        }
    }

    void Orbit()
    {
        distance = Mathf.Sqrt(Vector3.Distance(planetLocation.transform.position, transform.position));
        force = gravitationalConstant * ((bulletMass * planetMass) / distance);
        transform.position = new Vector3(planetLocation.transform.position.x + Mathf.Cos(angle) * force, planetLocation.transform.position.y + Mathf.Sin(angle) * force / 2, 0f);
        angle = angle + Time.deltaTime * speed;

        if (angle >= 360)
        {
            angle = 0;
        }
    }

    void PointForceGenerator()
    {
        Vector3 diff = mPoint - transform.position;

        float range = 10;
        float rangeSQ = range * range;

        float dist = Vector3.Distance(mPoint, transform.position);
        float distSQ = Mathf.Sqrt(dist);

        if(distSQ < rangeSQ)
        {
            dist = Vector3.Distance(mPoint, transform.position);
            float proportionAway = dist / range;
            proportionAway = 1 - proportionAway;
            diff.Normalize();

            diff = diff * mMagnitude * proportionAway * Time.deltaTime;
            accumulatedForces += diff;
        }
    }
}

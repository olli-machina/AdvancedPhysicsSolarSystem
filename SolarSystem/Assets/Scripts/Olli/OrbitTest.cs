using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTest : MonoBehaviour
{
    Planet currentOrbit;
    public double sunMass = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentOrbit = GetComponent<Planet>();
    }

    // Update is called once per frame
    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        double distanceAcc = calculateDistanceAcc(currentOrbit);
        currentOrbit.distSpeed = newValue(currentOrbit.distSpeed, distanceAcc);
        currentOrbit.distanceVal = newValue(currentOrbit.distanceVal, currentOrbit.distSpeed);

        double angleAcc = calculateAngleAcc(currentOrbit);
        currentOrbit.angleSpeed = newValue(currentOrbit.angleSpeed, angleAcc);
        currentOrbit.angleVal = newValue(currentOrbit.angleVal, currentOrbit.angleSpeed);
    }

    public double calculateDistanceAcc(Planet calcPlanet) //forces between due to gravity
    {
        double distance = calcPlanet.distanceVal;
        double angleSpeed = calcPlanet.angleSpeed;
        double gravity = calcPlanet.gravitationalConstant * sunMass;

        double acc = distance * Mathf.Pow((float)angleSpeed, 2) - gravity / Mathf.Pow((float)distance, 2);

        return acc;
    }

    public double calculateAngleAcc(Planet calcPlanet)
    {
        return (-2.0 * calcPlanet.distSpeed * calcPlanet.angleSpeed / calcPlanet.distanceVal);
    }

    public double newValue(double current, double derivative)
    {
        return (current + Time.deltaTime * derivative);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public ForceManager Fmanager;
   public ParticleManager Pmanager;
   //public Particle2DLink mLink;
   //public Particle2DContact pContact;
   public GameObject planetPrefab, sunPrefab, currentPlanet;
   //bool isSun = false;

    public int planetCountOnScreen = 0, planetDesired = 1;
    public float sunMass = 10f;

   // Start is called before the first frame update
   void Start()
   {
        CreateCenterPlanet(new Vector3(0f,0f,0f));
        currentPlanet = GameObject.Find("Earth?");
        ChangePlanet();
   }


    private void OnDrawGizmos()
    {
        Vector3 penPoint = new Vector3(0f,10f,0f);
        Gizmos.color = Color.blue; //both upper and lower FOV bounds
        Gizmos.DrawRay(penPoint, /*currentPlanet.transform.forward.normalized*/(currentPlanet.transform.position - penPoint).normalized * (Vector3.Distance(currentPlanet.transform.position, penPoint)));
    }
    // Update is called once per frame
    void Update()
   {
        if (planetCountOnScreen < planetDesired)
        {
            CreatePlanet(new Vector3(20f, 0f, 0f));
            planetCountOnScreen++;
        }

        //if (!isSun)
        //    CreateCenterPlanet(Vector3.zero);

   }


    void ChangePlanet()
    {
        Pmanager.addParticle2D(currentPlanet);
        currentPlanet.GetComponent<Planet>().SetVariables(currentPlanet);
        Planet newPlanetData = currentPlanet.GetComponent<Planet>();
        Particle2D newPlanetParticle = currentPlanet.GetComponent<Particle2D>();
        ForceGenerator2D orbitForce = Fmanager.NewOrbitForceGenerator(Vector3.zero, newPlanetData.gravitationalConstant, newPlanetParticle.Mass, sunMass);
        Fmanager.addForceGenerator(orbitForce);
        currentPlanet.GetComponent<Planet>().forceGen = orbitForce;
    }
    void CreatePlanet(Vector3 pos)
    {
        GameObject newPlanet = Instantiate(planetPrefab);
        newPlanet.transform.position = pos;
        Pmanager.addParticle2D(newPlanet);
        newPlanet.GetComponent<Planet>().SetVariables(newPlanet);
        Planet newPlanetData = newPlanet.GetComponent<Planet>();
        Particle2D newPlanetParticle = newPlanet.GetComponent<Particle2D>();
        ForceGenerator2D gravityForce = Fmanager.NewGravityForceGenerator(GameObject.Find("Sun"), newPlanet);
        Fmanager.addForceGenerator(gravityForce);
        newPlanet.GetComponent<Planet>().forceGen = gravityForce;
    }

    void CreateCenterPlanet(Vector3 pos)
    {
        //isSun = true;
        GameObject newSun = Instantiate(sunPrefab);
        newSun.name = "Sun";
        newSun.transform.position = pos;
        Pmanager.addParticle2D(newSun);
        newSun.GetComponent<CenterPlanet>().SetVariables(newSun);
        //ForceGenerator2D pointForce = Fmanager.NewPointForceGenerator(pos, 1000f);
        //Fmanager.addForceGenerator(pointForce);
        //newSun.GetComponent<CenterPlanet>().forceGen = pointForce;
    }


   
}

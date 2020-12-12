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
        ForceGenerator2D orbitForce = Fmanager.NewOrbitForceGenerator(Vector3.zero, newPlanetData.gravitationalConstant, newPlanetParticle.Mass, sunMass);
        Fmanager.addForceGenerator(orbitForce);
        newPlanet.GetComponent<Planet>().forceGen = orbitForce;
    }

    void CreateCenterPlanet(Vector3 pos)
    {
        //isSun = true;
        GameObject newSun = Instantiate(sunPrefab);
        newSun.name = "Sun";
        newSun.transform.position = pos;
        Pmanager.addParticle2D(newSun);
        newSun.GetComponent<CenterPlanet>().SetVariables(newSun);
        ForceGenerator2D pointForce = Fmanager.NewPointForceGenerator(pos, 1000f);
        Fmanager.addForceGenerator(pointForce);
        newSun.GetComponent<CenterPlanet>().forceGen = pointForce;
    }


    //void CreateTarget(Vector3 pos)
    //{
    //   GameObject newTarget = Instantiate(target);
    //   newTarget.transform.position = pos;
    //   Debug.Log(Pmanager);
    //   Pmanager.addParticle2D(newTarget);
    //   newTarget.GetComponent<TargetBehavior>().SetVariables(newTarget);
    //   ForceGenerator2D bouyancyForce = Fmanager.NewBouyancyForceGenerator(newTarget, -(waterSprite.transform.localScale.y) / 2, 75.0f, (waterSprite.transform.localScale.y) / 2, 5.0f);
    //   Fmanager.addForceGenerator(bouyancyForce);
    //   newTarget.GetComponent<TargetBehavior>().forceGen = bouyancyForce;
    //   isTarget = true;
    //}

    //void SpringProjectile()
    //{
    //   GameObject newBullet1 = Instantiate(springPrefab);
    //   GameObject newBullet2 = Instantiate(springPrefab);
    //   newBullet1.GetComponent<BulletBehavior>().SetVariables(newBullet1, gun);
    //   newBullet2.GetComponent<BulletBehavior>().SetVariables(newBullet2, gun);
    //   newBullet1.transform.position = gun.transform.position;
    //   newBullet2.transform.position = gun.transform.position;

    //   newBullet1.GetComponent<BulletBehavior>().isForceGen = true;

    //   ForceGenerator2D springForce = Fmanager.NewSpringForceGenerator(newBullet1, newBullet2, 1.0f, 10.0f);
    //   Fmanager.addForceGenerator(springForce);

    //   newBullet1.GetComponent<BulletBehavior>().forceGen = springForce;
    //}

    //void RodProjectile()
    //{
    //   GameObject newBullet1 = Instantiate(rodPrefab);
    //   GameObject newBullet2 = Instantiate(rodPrefab);
    //   newBullet1.GetComponent<BulletBehavior>().SetVariables(newBullet1, gun);
    //   newBullet2.GetComponent<BulletBehavior>().SetVariables(newBullet2, gun);
    //   newBullet1.transform.position = new Vector3(gun.transform.position.x, gun.transform.position.y + 10.0f, 0.0f);
    //   newBullet2.transform.position = gun.transform.position;

    //   newBullet1.GetComponent<BulletBehavior>().isParticleLink = true;

    //   Particle2DLink pLink = mLink.NewLink(newBullet1, newBullet2, 10.0f);
    //   //pContact.resolveContacts(mLink., Time.deltaTime);
    //   newBullet1.GetComponent<BulletBehavior>().particleLink = pLink;
    //}
}

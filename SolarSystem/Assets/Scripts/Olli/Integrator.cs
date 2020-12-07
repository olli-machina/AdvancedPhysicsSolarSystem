//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Integrator : MonoBehaviour
//{
//    Planet particle;

//    // Start is called before the first frame update
//    void Start()
//    {
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    public void integrator(GameObject obj)
//    {
//        particle = obj.GetComponent<Planet>();
//        obj.transform.position += (particle.velocity * Time.deltaTime);
//        Vector3 resultingAcc = particle.acceleration;

//        //if (!particle.ShouldIgnoreForces)
//        //{
//            resultingAcc += particle.accumulatedForces * (float)(particle.mass / 1.0);
//        //}

//        particle.velocity += (resultingAcc * Time.deltaTime);
//        //float damping = Mathf.Pow(particle.getDampingConstant(), Time.deltaTime);
//        //particle.velocity *= damping;

//        particle.ClearAccumulatedForces();
//    }
//}

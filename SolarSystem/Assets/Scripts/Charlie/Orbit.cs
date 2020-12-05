using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
   public float alpha = 0f;
   public float orbitSpeed = 1.0f;
   public float tilt = 0f;
   public float semiMajor = 10f;
   public float semiMinor = 5f;
   public float startingX = 0f;
   public float startingY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void LateUpdate()
   {
      OrbitMath();
   }

   void OrbitMath()
   {
      transform.position = new Vector3(startingX + (semiMajor * MCos(alpha) * MCos(tilt)) - (semiMinor * MSin(alpha) * MSin(tilt)), 
                                      startingY + (semiMajor * MCos(alpha) * MSin(tilt)) + (semiMinor * MSin(alpha) * MCos(tilt)));

      alpha += orbitSpeed;
   }

   float MCos(float value)
   {
      return Mathf.Cos(Mathf.Deg2Rad * value);
   }
   float MSin(float value)
   {
      return Mathf.Sin(Mathf.Deg2Rad * value);
   }
}

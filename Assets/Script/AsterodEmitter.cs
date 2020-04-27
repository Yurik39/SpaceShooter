using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterodEmitter : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;

    float nextLaunch; //Время запуска следующего астероида
    
    
    void Update()
    {
        if (Time.time > nextLaunch)
        {
            //Выпускайте астероид
            float size = transform.localScale.x;

            float xPos = Random.Range(-size / 2, size / 2);

            Vector3 asteroidPosition = new Vector3(xPos, 0, transform.position.z);

            GameObject newAsteroid = Instantiate(asteroid, asteroidPosition, Quaternion.identity);

            float resize = Random.Range(0.3f, 1.5f);
            newAsteroid.transform.localScale *= resize;
        

            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float rotationMinSpeed, rotationMaxSpeed;
    public float minSpeed, maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * Random.Range(rotationMinSpeed, rotationMaxSpeed);
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
        
    }
    //Срабатывает при вхождении, при столкновении коллайдеров
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        else
        {
            GameControllerScript.instanse.incrementScore(10);
        }

        Destroy(gameObject); //Уничтожаем текущий объект
        Destroy(other.gameObject);//Уничтожаем второй объект
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }
    
}

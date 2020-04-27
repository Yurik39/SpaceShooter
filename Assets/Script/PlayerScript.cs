using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject laserShot; 
    public Transform laserGun1, laserGun2;
    public float shotDelay;

    public float xMax, xMin, zMax, zMin;

    public float speed;
    public float tilt;
    Rigidbody playerShip;
    float nextShot; //время следующего выстрела
    
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        playerShip.rotation = Quaternion.Euler(tilt * playerShip.velocity.z, 0, -tilt * playerShip.velocity.x);

        float newXposition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float newZposition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(newXposition, 0, newZposition);

        if (Time.time > nextShot && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGun1.position, Quaternion.identity);
            Instantiate(laserShot, laserGun2.position, Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
    }
}

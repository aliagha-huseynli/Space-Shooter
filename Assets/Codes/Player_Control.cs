using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    Rigidbody physics;
    float h = 0; //Horizontal
    float v = 0; //Vertical
    Vector3 vec;
    public float Player_Speed; //For Player Ship Speed
    public float minX, maxX, minZ, maxZ; //Border For Player
    public float tend;
    public float firePassingTime;
    public GameObject Bullet;
    public Transform AppearBulletPlace;
    float fireTime = 0;
    AudioSource audio;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && (Time.time > fireTime))
        {
            fireTime = Time.time + firePassingTime;
            Instantiate(Bullet, AppearBulletPlace.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        vec = new Vector3(h,1,v); //Moving

        physics.velocity = vec * Player_Speed; // For Player Ship Speed

        physics.position = new Vector3
        (
                Mathf.Clamp(physics.position.x, minX, maxX),
            0.0f,
                Mathf.Clamp(physics.position.z, minZ, maxZ)
        );

        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x*(-tend));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Move : MonoBehaviour
{
    Rigidbody physics;
    public float velocity;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward * velocity;
    }
}

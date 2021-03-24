using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject explode;
    public GameObject playerExplode;

    GameObject GameControl;
    GameControl control;

    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("gamecontrol");
        control = GameControl.GetComponent<GameControl>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag != "BorderRear")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explode, transform.position, transform.rotation);
            control.AddScore(10);
        }
        

        if(col.tag == "Player")
        {
            Instantiate(playerExplode, col.transform.position, col.transform.rotation);
            control.gameOver();
        }
    }
}

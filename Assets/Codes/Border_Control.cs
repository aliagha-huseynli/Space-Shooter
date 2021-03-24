using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Control : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }
}

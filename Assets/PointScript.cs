using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float value = 1;
    public string type = "Sphere";
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hole")
        {
            HoleScript hole = col.gameObject.GetComponent<HoleScript>();
            hole.AddToScore(value, type);
            Destroy(gameObject);
        }
    }
}

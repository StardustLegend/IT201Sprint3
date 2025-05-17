using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawnerScript : MonoBehaviour
{
    public float SpawnTime;
    public GameObject[] PointShapes;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        GameObject Spawn = Instantiate(PointShapes[0], gameObject.transform.position, gameObject.transform.rotation);
    }
}

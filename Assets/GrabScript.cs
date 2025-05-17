using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrabScript : MonoBehaviour
{

    public bool Grabbed = false;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnMouseDown()
    {
        Grabbed = true;
    }
    public void OnMouseUp()
    {
        Grabbed = false;
    }
}

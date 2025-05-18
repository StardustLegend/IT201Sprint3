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
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        Grabbed = true;
        rb.velocity = Vector3.zero;
    }
    public void OnMouseUp()
    {
        Grabbed = false;
    }
}

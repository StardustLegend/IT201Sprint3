using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public Vector3 mousePos;

    public bool Grabbed = false;

    public Rigidbody rb;

    public float z_coord = -5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity) && Grabbed) {
            mousePos = hit.point;
            mousePos.z = z_coord;
            gameObject.transform.position = mousePos;
        }
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

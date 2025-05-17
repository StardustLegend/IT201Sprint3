using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabberScript : MonoBehaviour
{
    public Vector3 mousePos;

    public float z_coord = -5;
    public float max_z = 0;
    public float min_z = -10;

    // Update is called once per frame
    void Update()
    {
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            mousePos = hit.point;
            mousePos.z = z_coord;
            if (hit.collider.tag == "Point")
            {
                GrabScript grab = hit.collider.gameObject.GetComponent<GrabScript>();
                if (grab != null)
                {
                    if (grab.Grabbed)
                    {
                        hit.collider.gameObject.transform.position = mousePos;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            z_coord -= 0.02f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z_coord += 0.02f;
        }
        Mathf.Clamp(z_coord, min_z, max_z);
    }
}
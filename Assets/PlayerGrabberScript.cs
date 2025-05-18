using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGrabberScript : MonoBehaviour
{
    public ScoreAndShopScript ScoreAndShop;
    public Vector3 mousePos;

    public bool Z_set = false;

    public float z_coord = -5;
    public float max_z = 0;
    public float min_z = -10;

    public bool SplitterMode = false;
    public bool ThinnerMode = false;
    public bool ShrinkerMode = false;

    public float shrinkFactor = 0.75f;

    public TMP_Text DescriptionText;
    // Update is called once per frame
    void Update()
    {
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Point")
            {
                GrabScript grab = hit.collider.gameObject.GetComponent<GrabScript>();
                if (grab != null)
                {
                    if (grab.Grabbed)
                    {
                        if (SplitterMode)
                        {
                            if (ScoreAndShop.points >= ScoreAndShop.SplitterPrice)
                            {
                                hit.collider.gameObject.transform.localScale = ChangeScale(hit.collider.gameObject.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f));
                                GameObject newPoint = Instantiate(hit.collider.gameObject, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                                ScoreAndShop.points -= ScoreAndShop.SplitterPrice;
                            }
                            else
                            {
                                DescriptionText.text = "Not enough points to use the Splitter!";
                            }
                        }
                        if (ThinnerMode)
                        {
                            if (ScoreAndShop.points >= ScoreAndShop.ThinnerPrice)
                            {
                                hit.collider.gameObject.transform.localScale = ChangeScale(hit.collider.gameObject.transform.localScale, new Vector3(shrinkFactor, 1, 1));
                                ScoreAndShop.points -= ScoreAndShop.ThinnerPrice;
                            }
                            else
                            {
                                DescriptionText.text = "Not enough points to use the Thinner!";
                            }
                        }
                        if (ShrinkerMode)
                        {
                            if (ScoreAndShop.points >= ScoreAndShop.ShrinkerPrice)
                            {
                                hit.collider.gameObject.transform.localScale = ChangeScale(hit.collider.gameObject.transform.localScale, new Vector3(shrinkFactor, shrinkFactor, shrinkFactor));
                                ScoreAndShop.points -= ScoreAndShop.ShrinkerPrice;
                            }
                            else
                            {
                                DescriptionText.text = "Not enough points to use the Shrinker!";
                            }
                        }
                        mousePos = hit.point;
                        Set_Z(hit.collider.gameObject.transform.position);
                        mousePos.z = z_coord;
                        hit.collider.gameObject.transform.position = mousePos;
                    }
                    else
                    {
                        Z_set = false;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            z_coord += 0.02f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z_coord -= 0.02f;
        }
        Mathf.Clamp(z_coord, min_z, max_z);
    }
    public Vector3 ChangeScale(Vector3 curVector, Vector3 scaleVector)
    {
        Vector3 newScale = curVector;
        newScale.x *= scaleVector.x;
        newScale.y *= scaleVector.y;
        newScale.z *= scaleVector.z;
        return newScale;
    }
    public void ToggleSplitMode()
    {
        SplitterMode = !SplitterMode;
        ThinnerMode = false;
        ShrinkerMode = false;
        DescriptionText.text = "The splitter lets you split any object into two smaller version of it, both with the same point value!";
    }
    public void ToggleThinMode()
    {
        SplitterMode = false;
        ThinnerMode = !ThinnerMode;
        ShrinkerMode = false;
        DescriptionText.text = "the thinner makes an object slightly thinner along 1 axis!";
    }
    public void ToggleShrinkMode()
    {
        SplitterMode = false;
        ThinnerMode = false;
        ShrinkerMode = !ShrinkerMode;
        DescriptionText.text = "use the shrinker to shrink an object so it can fit in a hole better!";
    }
    public void GrabOnlyMode()
    {
        SplitterMode = false;
        ThinnerMode = false;
        ShrinkerMode = false;
    }
    void Set_Z(Vector3 CurPos)
    {
        if (Z_set == false)
        {
            z_coord = CurPos.z;
        }
        Z_set = true;
    }
}
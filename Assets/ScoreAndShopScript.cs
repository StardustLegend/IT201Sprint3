using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class ScoreAndShopScript : MonoBehaviour
{
    public float points = 0;
    public bool TaskSelected = false;
    public TMP_Text Point_Text;
    void Update()
    {
        Point_Text.text = "Points: " + points.ToString();
    }
}

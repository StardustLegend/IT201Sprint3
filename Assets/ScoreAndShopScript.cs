using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class ScoreAndShopScript : MonoBehaviour
{
    public PlayerGrabberScript PlayerGrabber;
    public float points = 0;
    public bool TaskSelected = false;
    public TMP_Text Point_Text;
    public TMP_Text ToggleTaskButtonText;

    public float SplitterPrice = 2f;
    public float ShrinkerPrice = 1f;
    public float ThinnerPrice = 0.5f;

    public TMP_Text SplitterText;
    public TMP_Text ShrinkerText;
    public TMP_Text ThinnerText;
    void Update()
    {
        Point_Text.text = "Points: " + points.ToString();
        SplitterText.text = "Splitter (" + SplitterPrice.ToString() + " points to use)";
        ShrinkerText.text = "Shrinker (" + ShrinkerPrice.ToString() + " points to use)";
        ThinnerText.text = "Thinner (" + ThinnerPrice.ToString() + " points to use)";
        if (PlayerGrabber.SplitterMode)
        {
            SplitterText.text = "(SELECTED) Splitter (" + SplitterPrice.ToString() + " points to use)";
        }
        if (PlayerGrabber.ShrinkerMode)
        {
            ShrinkerText.text = "(SELECTED) Shrinker (" + ShrinkerPrice.ToString() + " points to use)";
        }
        if (PlayerGrabber.ThinnerMode)
        {
            ThinnerText.text = "(SELECTED) Thinner (" + ThinnerPrice.ToString() + " points to use)";
        }
        if (TaskSelected)
        {
            ToggleTaskButtonText.text = "Deselect Tasks";
        }
        else
        {
            ToggleTaskButtonText.text = "Select Tasks";
        }
    }
    public void ToggleTaskSelect()
    {
        TaskSelected = !TaskSelected;
    }
}

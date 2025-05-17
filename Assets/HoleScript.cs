using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public float value_multiplier = 1;
    public ScoreAndShopScript Score_Shop;
    public TaskManagerScript Task_Manager;
    void Start()
    {
        Score_Shop = GameObject.Find("ScoreAndShopManager").GetComponent<ScoreAndShopScript>();
    }
    public void AddToScore(float points)
    {
        float addValue = value_multiplier * points;
        if (Score_Shop.TaskSelected)
        {
            if (Task_Manager.selected_task.HasHole(gameObject))
            {
                Score_Shop.points += addValue;
            }
        }
        else
        {
            Score_Shop.points += addValue;
        }
    }
}

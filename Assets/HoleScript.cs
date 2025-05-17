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
        Task_Manager = GameObject.Find("ScoreAndShopManager").GetComponent<TaskManagerScript>();
    }
    public void AddToScore(float points, string type)
    {
        float addValue = value_multiplier * points;
        if (Score_Shop.TaskSelected)
        {
            if (Task_Manager.cur_tasks[Task_Manager.selected_task_index].HasHole(gameObject))
            {
                Task_Manager.Subtract(Task_Manager.selected_task_index, type);
                print(type + " needed remaining: " + Task_Manager.cur_tasks[Task_Manager.selected_task_index].needed_spheres.ToString());
            }
        }
        else
        {
            Score_Shop.points += addValue;
        }
    }
}

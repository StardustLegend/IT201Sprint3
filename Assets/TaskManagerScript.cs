using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManagerScript : MonoBehaviour
{
    public ScoreAndShopScript Score_And_Shop;
    public List<JobTask> tasks;
    public int max_active_tasks = 3;
    public List<JobTask> cur_tasks;
    public int selected_task_index = 0;
    public List<float> task_times = new List<float>();
    public TMP_Text TaskText;
    [Serializable]
    public class JobTask
    {
        public string company_name;
        public string task_description;
        public int init_needed_spheres;
        public int init_needed_cubes;
        public int needed_spheres;
        public int needed_cubes;
        public float expiration_time;
        public float point_payout;
        public List<GameObject> holes;

        public bool HasHole(GameObject obj)
        {
            if (holes.Contains(obj)) 
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetBaseValues()
        {
            needed_spheres = init_needed_spheres;
            needed_cubes = init_needed_cubes;
        }
        public void SubtractFromNeed(string type)
        {
            if (type == "Sphere")
            {
                //print("For task " + company_name + " needed spheres remaining: " + needed_spheres.ToString());
                needed_spheres -= 1;
            }
            if (type == "Cube")
            {
                needed_cubes -= 1;
            }
        }
    }
    void Start()
    {
        for (int i = 0; i < max_active_tasks; i++)
        {
            cur_tasks.Add(tasks[(int) UnityEngine.Random.Range(0, tasks.Count)]);
        }
        foreach (JobTask task in cur_tasks)
        {
            task_times.Add(task.expiration_time);
            task.SetBaseValues();
        }
    }
    void Update()
    {
        TaskText.text = "";
        for (int i = 0; i < task_times.Count; i++)
        {
            task_times[i] -= Time.deltaTime;
            //print("Task time #" + i.ToString() + ": " + task_times[i].ToString());
            if (i == selected_task_index && Score_And_Shop.TaskSelected)
            {
                TaskText.text += "(Selected)";
            }
            TaskText.text += "Task #" + (i + 1).ToString() + " for " + cur_tasks[i].company_name + ": " + Mathf.Round(task_times[i]).ToString() + "s remaining\n";
            print("Task #" + (i + 1).ToString() + ": Spheres needed " + cur_tasks[i].needed_spheres.ToString());
            if (cur_tasks[i].needed_cubes <= 0 && cur_tasks[i].needed_spheres <= 0) //might be more efficient to check this in the hole script but it's fine for now
            {
                print("Task #" + (i + 1).ToString() + " successfully completed!");
                Score_And_Shop.points += cur_tasks[i].point_payout;
                cur_tasks[i].SetBaseValues();
                NewTask(i);
                break;
            }
            if (task_times[i] < 0)
            {
                NewTask(i);
            }
        }
        TaskText.text += "\n Order Statement from " + cur_tasks[selected_task_index].company_name + "- \n" + cur_tasks[selected_task_index].task_description + "\n \n Point payout: " + cur_tasks[selected_task_index].point_payout.ToString() + " points";
    }
    public void Subtract(int task_index, string type)
    {
        cur_tasks[task_index].SubtractFromNeed(type);
    }
    void NewTask(int index)
    {
        task_times.RemoveAt(index);
        cur_tasks.RemoveAt(index);
        int new_random = (int)UnityEngine.Random.Range(0, tasks.Count);
        cur_tasks.Add(tasks[new_random]);
        cur_tasks[max_active_tasks - 1].SetBaseValues();
        task_times.Add(tasks[new_random].expiration_time);
        
    }
    public void ToggleTaskSelection()
    {
        selected_task_index += 1;
        if (selected_task_index >= max_active_tasks)
        {
            selected_task_index = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManagerScript : MonoBehaviour
{
    public List<JobTask> tasks;
    public int max_active_tasks = 3;
    public List<JobTask> cur_tasks;
    public JobTask selected_task;
    public List<float> task_times = new List<float>();
    public TMP_Text TaskText;
    [Serializable]
    public struct JobTask
    {
        public string company_name;
        public string task_description;
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
        }
    }
    void Update()
    {
        TaskText.text = "";
        for (int i = 0; i < task_times.Count; i++)
        {
            task_times[i] -= Time.deltaTime;
            //print("Task time #" + i.ToString() + ": " + task_times[i].ToString());
            TaskText.text += "Time for Task #" + (i + 1).ToString() + ": " + Mathf.Round(task_times[i]).ToString() + "\n";
            if (task_times[i] < 0)
            {
                task_times.RemoveAt(i);
                cur_tasks.RemoveAt(i);
                int new_random = (int)UnityEngine.Random.Range(0, tasks.Count);
                cur_tasks.Add(tasks[new_random]);
                task_times.Add(tasks[new_random].expiration_time);
            }
        }
    }
}

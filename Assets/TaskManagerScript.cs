using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerScript : MonoBehaviour
{
    public List<JobTask> tasks;
    public int max_active_tasks = 3;
    public List<JobTask> cur_tasks;
    public JobTask selected_task;
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
    }
    void Update()
    {

    }
}

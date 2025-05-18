using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Specialized;
public class ShapeSpawnerScript : MonoBehaviour
{
    public ScoreAndShopScript ScoreAndShop;
    public float BaseSpawnTime = 7.5f;
    public float SpawnTime;
    public float ProductionIncreaseFactor = 0.9f;
    public float ProductionUpgradePrice = 10f;
    public GameObject[] PointShapes; //0 is a sphere, 1 is a cube
    public float SphereToCubeRatio = 0f; //0 is all spheres, 1 is all cubes
    public TMP_Text RatioText;
    public TMP_Text DescriptionText;
    public Slider ratioSlider;
    public float ScaleRandomizerMin = 0.875f;
    public float ScaleRandomizerMax = 1.55f;
    void Start()
    {
        SpawnTime = BaseSpawnTime;
        InvokeRepeating("Spawn", 0f, SpawnTime);
    }
    
    void Update()
    {
        RatioText.text = "Sphere Cube Ratio: " + SphereToCubeRatio.ToString();
        SphereToCubeRatio = ratioSlider.value;
    }
    public void IncreaseProduction()
    {
        if (ScoreAndShop.points >= ProductionUpgradePrice)
        {
            ScoreAndShop.points -= ProductionUpgradePrice;
            CancelInvoke("Spawn");
            SpawnTime *= ProductionIncreaseFactor;
            InvokeRepeating("Spawn", 0f, SpawnTime);
            DescriptionText.text = "Shape Production increased by " + ((1 - ProductionIncreaseFactor) * 100).ToString() + "%!";
        }
        else
        {
            DescriptionText.text = "Not enough points to increase shape production!";
        }
    }
    void Spawn()
    {
        float ratio = UnityEngine.Random.Range(0f, 1f);
        print("random: " + ratio.ToString());
        if (ratio > SphereToCubeRatio) //if it's greater than the ratio, spawn a sphere
        {
            GameObject Spawn = Instantiate(PointShapes[0], gameObject.transform.position, gameObject.transform.rotation);
            Vector3 SpawnScale = Spawn.transform.localScale;
            SpawnScale *= UnityEngine.Random.Range(0.875f, 1.15f);
            Spawn.transform.localScale = SpawnScale;
        }
        else
        {
            GameObject Spawn = Instantiate(PointShapes[1], gameObject.transform.position, gameObject.transform.rotation);

        }
    }
}

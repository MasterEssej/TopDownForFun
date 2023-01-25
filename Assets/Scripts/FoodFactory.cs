using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;
    private Alteruna.Spawner spawner;
    Vector3 scale;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<Alteruna.Spawner>();
        spawner.SpawnableObjects.Add(foodPrefab);
        spawner.ForceSync = true;
        scale = new Vector3(0.5f, 0.5f, 1f);
    }

    public GameObject Create(int level, Vector3 pos)
    {
        GameObject Food = spawner.Spawn(0, pos, Quaternion.identity, scale);
        Food.GetComponent<Food>().FoodConstructor(level);

        return Food;
    }
}

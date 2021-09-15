using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerManager : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Vector3 instancePoint;

    Stack<GameObject> hitmarkerpool;

    public static HitMarkerManager hitinstance;
    // Start is called before the first frame update
    void Start()
    {
        hitinstance = this;
        hitmarkerpool = new Stack<GameObject>();
        CreatePrefabs(1);
    }

    void CreatePrefabs(int value)
    {
        for (int i = 0; i < value; i++)
        {
            hitmarkerpool.Push(Instantiate(hitMarkerPrefab));
            hitmarkerpool.Peek().SetActive(false);
        }
    }
    public void AddHitMarkerPool(GameObject tempObj)
    {
        hitmarkerpool.Push(tempObj);
        hitmarkerpool.Peek().SetActive(false);
    }
    public void SpawnMarker()
    {
        if (hitmarkerpool.Count == 0)
        {
            CreatePrefabs(1);
        }
        GameObject temp = hitmarkerpool.Pop();
        temp.SetActive(true);
        temp.transform.position = instancePoint;
    }
}
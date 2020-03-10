using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public Transform trash;
    public int trashnum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            Instantiate(trash, new Vector3(Random.Range(35, -35), 0, Random.Range(20, -20)), Quaternion.identity);
            trashnum = 40;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trashnum <= 40)
        {
            Instantiate(trash, new Vector3(Random.Range(35, -35), 0, Random.Range(20, -20)), Quaternion.identity);
            trashnum += 1;  
        }
        
    }
}

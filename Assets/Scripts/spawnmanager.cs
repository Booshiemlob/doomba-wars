using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE
{
    public class spawnmanager : MonoBehaviour
    {
        public Transform trash;
        public Rigidbody rb;
        public float forceAdded = 10f;
        Transform go;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 100; i++)
            {

                go = Instantiate(trash, new Vector3(Random.Range(25, -25), 50, Random.Range(20, -20)), Quaternion.identity);
                rb = go.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(Random.Range(3, -3), Random.Range(3, -3), Random.Range(3, -3))*forceAdded);
                GameManager_Test1.trashCount = 100;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager_Test1.trashCount <= 100)
            {

                go = Instantiate(trash, new Vector3(Random.Range(25, -25), 50, Random.Range(20, -20)), Quaternion.identity);
                rb = go.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(Random.Range(3, -3), Random.Range(3, -3), Random.Range(3, -3)) * forceAdded);
                GameManager_Test1.trashCount++;
            }

        }
    }
}


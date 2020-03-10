using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE
{ 
    public class DestroyMe : MonoBehaviour
    {
    // Start is called before the first frame update
        void Start()
         {
        
         }

    // Update is called once per frame
        void OnDestroy()
        {
            GameManager_Test1.trashCount--;
        }
    }
}
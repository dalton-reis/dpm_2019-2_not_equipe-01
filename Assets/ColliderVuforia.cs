﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderVuforia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "cl") {
            Debug.Log("Teste  de comparação");
            if (other.gameObject.CompareTag("Na"))
            {
                Debug.Log("NaCl");
            }
        }
    }
}

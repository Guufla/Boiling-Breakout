using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // change load scene
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene("RisingWaterTester");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        {
            SceneManager.LoadScene("LoseMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

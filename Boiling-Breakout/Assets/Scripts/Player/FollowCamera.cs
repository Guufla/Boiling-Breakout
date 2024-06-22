using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform player;

    public float smoothSpeed;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed * Time.deltaTime);
    }
}

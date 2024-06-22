using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;


    public float totalJumps;
    public float totalDashes;
    private float dashCooldown = 180;


    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;
    private float dashInput;
    



    private float fixedRotation = 0;



    

    private Rigidbody playerBody;

    void Start(){
        playerBody = GetComponent<Rigidbody>();
    }
    void Update(){
        


        // Tracks if its touching the ground
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out hit, 0.5f) && totalJumps == 0 ){
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            totalJumps = 2;
        }
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out hit, 0.5f) && totalDashes == 0){
            if(dashCooldown > 0){
                --dashCooldown;
            }
            else{
                totalDashes = 2;
                dashCooldown = 180;
            }
        }

        


        // Gets the player input;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // jumpInput = Input.GetAxis("Jump");            // This is not needed
        dashInput = Input.GetAxis("Fire3");

        // Move the player
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        
        // Jump
        if(Input.GetKeyDown(KeyCode.Space) && totalJumps > 0){
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            --totalJumps;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && totalDashes > 0){
            Debug.Log("Dash");
            playerBody.AddForce(2 * speed * horizontalInput , 0 , 2 * speed * verticalInput,ForceMode.Impulse);
            --totalDashes;
        }


    }

}

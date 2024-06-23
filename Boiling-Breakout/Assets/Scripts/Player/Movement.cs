using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float wallJumpForce;


    public float totalJumps;
    public float totalDashes;
    private float dashCooldown = 60;


    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;
    private float dashInput;
    
    private bool WallJump;






    

    private Rigidbody playerBody;

    void Start(){
        playerBody = GetComponent<Rigidbody>();
    }


    

    void Update(){
        

        // Tracks if its touching the ground
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out hit, 1f) && totalJumps == 0 ){
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            totalJumps = 2;
        }
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out hit, 1f) && totalDashes == 0){
            if(dashCooldown > 0){
                --dashCooldown;
            }
            else{
                totalDashes = 1;
                dashCooldown = 60;
            }
        }

        


        // Gets the player input;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // jumpInput = Input.GetAxis("Jump");            // This is not needed
        dashInput = Input.GetAxis("Fire3");

        
        // Jump and wall jump
        if(Input.GetKeyDown(KeyCode.Space) && totalJumps > 0){
            playerBody.velocity = new Vector3(playerBody.velocity.x,0f,playerBody.velocity.z);
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            --totalJumps;
        
           
        }
        else if (Input.GetKeyDown(KeyCode.Space) && WallJump == true){
            playerBody.velocity = new Vector3(playerBody.velocity.x,0f,playerBody.velocity.z);
            playerBody.AddForce(Vector3.up * wallJumpForce, ForceMode.Impulse);
            WallJump = false;
        }





        if(Input.GetKeyDown(KeyCode.LeftShift) && totalDashes > 0){
            Debug.Log("Dash");
            playerBody.velocity = new Vector3(0f,0f,0f);
            playerBody.AddForce(2 * speed * horizontalInput , 0 , 2 * speed * verticalInput,ForceMode.Impulse);
            --totalDashes;
        }


    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == 7){
            
            Debug.Log("Hit Wall");
            WallJump = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.layer == 7){
            
            Debug.Log("Left Wall");
            WallJump = false;
        }
    }


    void FixedUpdate(){
        // Moves the player
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    }

}

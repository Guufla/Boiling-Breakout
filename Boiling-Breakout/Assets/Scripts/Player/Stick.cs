using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stick : MonoBehaviour
{

    private GameObject player;
    private GameObject Enemy;

    public float numberToEscape;
    public float coolDown;
    private float curCoolDown;
    private float numCurrently;

    public bool isStuck = false;
    // Start is called before the first frame update
    void Start(){
    }

    void Update(){
        if(isStuck == true){
            gameObject.transform.position = Enemy.transform.position + Enemy.transform.forward;
        }
        if(Input.GetKeyDown(KeyCode.Space) && numCurrently > 0 && isStuck == true){
            numCurrently -= 1f;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && numCurrently <= 0 && isStuck == true){
            isStuck = false;
        }

        if(curCoolDown > 0 && isStuck == false){
            curCoolDown -= 1f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == 8 && curCoolDown <= 0){
            curCoolDown = coolDown;
            numCurrently = numberToEscape;
            Enemy = other.gameObject;
            isStuck = true;
        }
    }
}

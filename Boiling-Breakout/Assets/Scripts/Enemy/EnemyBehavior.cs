using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float attackSpeed;

    private Rigidbody enemyBody;


    // Patroling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    private bool isLunging = false;
    private bool isGrounded = true;

    private float dashTimer = 0f;


    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake(){
        player = GameObject.Find("Crab").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyBody = GetComponent<Rigidbody>();
    }

    private void Update(){
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange && !isLunging){
            Patroling();
        }
        if(playerInSightRange && !playerInAttackRange && !isLunging){
            Chase();
        }
        if(playerInAttackRange && playerInSightRange && !isLunging){
            Attack();
        }
        if(isLunging){
            if(dashTimer <= 0f && isGrounded){
                isLunging = false;
                agent.enabled = true;
            }
            else{
                dashTimer -= 1f * Time.deltaTime;
            }
        }

    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.layer == 3){
            Debug.Log("Grounded");
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other){
        if(other.gameObject.layer == 3){
            Debug.Log("Not Grounded");
            isGrounded = false;
        }
    }

    // State machine

    private void Patroling(){
        if(!walkPointSet){
            SearchWalkPoint();
        }
        if(walkPointSet){
            agent.SetDestination(walkPoint);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround)){
            walkPointSet = true;
        }
    }

    private void Chase(){
        
        agent.SetDestination(player.position);
        Vector3 targetPosition = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void Attack(){
        agent.SetDestination(player.position);
        Vector3 targetPosition = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
        transform.LookAt(targetPosition);


        // Attack code 
        if(dashTimer <= 0){
            agent.enabled  = false;
            isLunging = true;
            isGrounded = false;
            dashTimer = 1f;
            Debug.Log("DASH?");
            enemyBody.AddForce(transform.up  * player.position.y * 8f, ForceMode.Impulse);
            enemyBody.AddForce(transform.forward * 40, ForceMode.Impulse);
        }

    }




}
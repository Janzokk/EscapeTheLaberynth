using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class MonsterController : MonoBehaviour
{   
    //Floor the enemy can navigate for
    public NavMeshAgent nma;
    public float speed = 8f;
    [Range(1,40)] public float walkRadius;   
    int i = 0;
    bool inRange = false;
    public GameObject uiObject;

    // Start is called before the first frame update
    public void Start()
    {
        uiObject.SetActive(false);
        
        //Get the navMesh
        nma = GetComponent<NavMeshAgent>();
        //if it exists
        if(nma != null){
            //Set speed and we move the monster to a random location
            nma.speed = speed;
            nma.SetDestination(RandomNavMeshLocation());
        }
    }
    public void Update() {
        //If player is in a certain range
        if (inRange){
            //The player becomes the objective
            nma.destination = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        }else
        //If the monster
        if (nma != null && nma.remainingDistance <= nma.stoppingDistance)
        {
            nma.SetDestination(RandomNavMeshLocation());
        }
                   
        
        
    }
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    

    void OnTriggerEnter(Collider col){
        if(col.transform.tag == "Player"){
            inRange = true;
        }
        
    }
} 
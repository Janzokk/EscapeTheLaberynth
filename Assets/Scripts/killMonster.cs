using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class killMonster : MonoBehaviour
{   
    //The enemy
    public GameObject go;
    //The navMesh
    public NavMeshAgent nma;

    //When something is seen (between a certain range) from the player
    private void OnTriggerEnter(Collider col){
        //If it is the enemy
        if(col.transform.tag == "lampCollision"){
            //Disable the walls
            nma.enabled = false;
            //Move the enemy to the respawn
            go.transform.position = new Vector3(-35f, 0f, -44f);
            //Enable the walls
            nma.enabled = true;
        }
    }
}

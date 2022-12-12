using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class killMonster : MonoBehaviour
{   
    public GameObject go;
    public NavMeshAgent nma;
    private void OnTriggerEnter(Collider col){
 
        if(col.transform.tag == "lampCollision"){
           nma.enabled = false;

            go.transform.position = new Vector3(-35f, 0f, -44f);
            nma.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathManager : MonoBehaviour
{
    // Game Objects per al deathManager
    public GameObject uiObject;
    // Text per imprimir al usuari
    public Text txt;
     
    // Controlar el event triggered 
    private void OnTriggerEnter(Collider col){
	// Si colisiona amb l'enemic, game over i al cap de 2 segons s'acaba el joc
        if(col.transform.tag == "enemy"){
            txt.text = "GAME OVER";
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    // Subrutina per a tancar l'aplicacio
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
        Application.Quit();

    }
}

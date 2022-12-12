using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class doorHandler : MonoBehaviour
{
    // Inventary del jugador
    public inventary inv;
    public GameObject uiObject;
    public Text txt;

    // Start 
    void Start()
    {
        // Obtenir Inventary
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventary>();
        // Amagar missatges de la pantalla
        uiObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider col)
    {
        // Controlar les colisions del jugador amb la porta
        if(col.transform.tag == "Player")
        {
	    // Si el jugador té dues keys, obrim la porta
            if(inv.key == 2)
            {
                // Obrir la porta
                gameObject.transform.Translate(0, 20f, 0);
                txt.text = "Door opened";
                Application.Quit();
            }else
            {
	        // Si el jugador no té les dues keys, mostra un missatge per tal d'aconseguir-les
                txt.text = "You need two keys to open this door";
            }
	    // S'amaga el missatge passats 5 segons
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
        
    }
}

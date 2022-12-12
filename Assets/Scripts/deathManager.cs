using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathManager : MonoBehaviour
{
    public GameObject uiObject;
    public Text txt;
      
    private void OnTriggerEnter(Collider col){

        if(col.transform.tag == "enemy"){
            txt.text = "GAME OVER";
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
        Application.Quit();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyCollector : MonoBehaviour
{
    public inventary inv;
    public GameObject uiObject;
    public Text txt;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {   //Get the player's inventary
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventary>();
        flag = false;
    } 

    //When something touches the keys
    private void OnTriggerEnter(Collider col){
        //If the is the player and is the first time he touched the key
        if(col.transform.tag == "Player" && !flag){
            //The amount of keys the player have augments
            inv.key += 1;
            flag = true;
            //We show a text to the player
            txt.text = "You got one key "+inv.key+"/2";

            uiObject.SetActive(true);
            //We make the key invisible
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //Activate the Coroutine
            StartCoroutine("WaitForSec");
        }
            
    }
    //Coroutine
    IEnumerator WaitForSec()
    {
        //Waits for 3 seconds
        yield return new WaitForSeconds(3);
        //Hides the text from the player
        uiObject.SetActive(false);
        //Destroy the key
        Destroy(gameObject);
    }
}

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
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventary>();
        flag = false;
    } 

    private void OnTriggerEnter(Collider col){
        if(col.transform.tag == "Player" && !flag){
            inv.key += 1;
            flag = true;
            txt.text = "You got one key "+inv.key+"/2";

            uiObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine("WaitForSec");
        }
            
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        uiObject.SetActive(false);
        Destroy(gameObject);
    }
}

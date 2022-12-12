using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class doorHandler : MonoBehaviour
{
    public inventary inv;
    public GameObject uiObject;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        // Obtenir Inventary
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventary>();
        // Amagar missatges de la pantalla
        uiObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            if(inv.key == 2)
            {
                // Obrir la porta
                gameObject.transform.Translate(0, 20f, 0);
                txt.text = "Door opened";
                Application.Quit();
            }else
            {
                txt.text = "You need two keys to open this door";
            }
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

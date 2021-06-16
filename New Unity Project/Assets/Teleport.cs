using UnityEngine;
using System.Collections;


public class Teleport : MonoBehaviour
{
    public Teleport destination;
    public int k = 0;
    /*
    void Start()
    {
        Debug.Log("in start k = " + k);
    }

    void Update()
    {
        Debug.Log("in update k = " + k);
    }
    */
    
    
    void OnTriggerEnter(Collider other)
    {
        /*
        Debug.Log("this.gameObject.name = "+ this.gameObject.name);
        if (this.gameObject.name == "Cube")
        {
        */
            other.transform.rotation = destination.transform.rotation;
            other.transform.position = destination.transform.position + new Vector3(5, 0, 5);
        /*
        }
        else
        {
            //Debug.Log("in trigger k = " + k);
            //Debug.Log("OnTriggerEnter:");

            if (k == 0)
            {
                other.transform.rotation = destination.transform.rotation;
                other.transform.position = destination.transform.position + new Vector3(5, 0, 5);

            }

            k = 0;

            StartCoroutine(GameObject.Find("EventSystem").GetComponent<Coroutiner>().TeleportTimer(k));
        }
        */
        
    }
    

}
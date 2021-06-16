using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Text hp;
    public GameObject gameObject;
    
    void Start()
    {
        hp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] objs = this.gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform obj in objs) {
            if (obj.name == "HealthBar(Clone)" && obj.transform.parent.tag == "Player")
            {
                HealthBar hb = obj.gameObject.GetComponent<HealthBar>();
                hp.text = hb.healthSystem.GetHealth().ToString();
            }
        }
    }
}

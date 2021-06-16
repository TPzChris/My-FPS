using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject GameObject; 
          public float x = 0.0f, y = 5.0f, z = -7.0f;
    void Update()
    {
        transform.position = GameObject.transform.position + new Vector3(x, y, z);
        
        
    }
}

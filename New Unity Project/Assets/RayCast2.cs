using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour
{
    /*
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        hit.transform.gameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHit();
    }

   

    void CheckForHit()
    {

        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("It Hurts");
                Debug.DrawLine(transform.position, hit.point);
                /* GameObject enemy = GameObject.FindWithTag("Enemy");
                 EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                 enemyHealth.maxHealth = -10;*/
            /*}
        }
    }*/

}

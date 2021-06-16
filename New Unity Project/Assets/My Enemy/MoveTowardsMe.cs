using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsMe : MonoBehaviour
{

    public GameObject target;
    public float speed = 2f;
    private bool updateOn = true;

    public void Awake()
    {
        StartCoroutine(updateOff());
        
    }

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target)
        {
            Debug.Log("da");

        }
        else
        {
            Debug.Log("nu");
        }
    }

    public void Update()
    {
        
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player"); 
        }
        if (updateOn == false)
        {
            Debug.Log("this "+transform.position);
            Debug.Log("that " + target.transform.position);
            Debug.Log(target);
            Vector3 targetDirection = target.transform.position - transform.position;
            Debug.Log(targetDirection);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime, 4f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    IEnumerator updateOff()
    {
        yield return new WaitForSeconds(10.0f);
        updateOn = false;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Collider[] Colliders;

    void Start()
    {

    }

    
    // Update is called once per frame
    void Update()
    {
        Colliders = Physics.OverlapSphere(transform.position, 0.3f);
        for (int i = 0; i < Colliders.Length; i++)
        {
            if (Colliders[i].tag == "Player" || Colliders[i].tag == "Enemy")
            {
                if (Colliders[i].gameObject != gameObject)
                { //if not hiting itself
                    Rigidbody rb = Colliders[i].gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Debug.Log("in al doilea if");
                        //rb.AddExplosionForce(power * 5, explosionPos, radius, 3.0F);
                        Debug.Log("rb = " + rb);
                        HealthBar healthBar = rb.GetComponentInChildren<HealthBar>();
                        if (healthBar != null)
                        {
                            Debug.Log("in al treilea if");
                            healthBar.healthSystem.Heal(1);

                            Debug.Log(healthBar.healthSystem.GetHealth());
                        }
                    }
                }
            }
        }
    }
}

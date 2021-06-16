using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem;
    public bool flag = false;
    public float explDist;
    public string test;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent() * 2, 0.25f);
    }

    public void Update()
    {
        if(this.flag == true)
        {
            Debug.Log(explDist);
            int damage = (int)(explDist * 100);
            this.healthSystem.Damage(damage);
            Debug.Log(damage);
            this.setFlag(false);
        }
    }

    public void setFlag(bool flag)
    {
        this.flag = flag;
    }

    public void setExplDist(float explDist)
    {
        this.explDist = explDist;
    }

    public HealthSystem getHealthSystem()
    {
        return this.healthSystem;
    }

    public void setHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }

    public void setTest(string test)
    {
        this.test = test;
        Debug.Log("test = "+test);
    }
}

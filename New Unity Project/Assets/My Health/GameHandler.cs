using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Transform HealthBar;
    HealthSystem healthSystem = new HealthSystem(100);
    HealthBar healthBar;

    private bool flag = true;
    //private int currentScore = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Awake()
    { 
        Transform healthBarTransform = Instantiate(HealthBar, transform.position + new Vector3(0, 2), Quaternion.identity);
        Debug.Log("here");
        Destroy(HealthBar);
        healthBar = healthBarTransform.GetComponent<HealthBar>();
        Debug.Log("hb " + healthBar);
        Debug.Log("hs " + healthSystem);
        healthBar.Setup(healthSystem);
        healthBar.transform.parent = gameObject.transform;
        //healthBar.transform.rotation = Quaternion.Euler(0, -90, 0);
        if(this.tag == "Enemy 2") this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        healthBar.setTest("GH");
        //if (this.tag == "Player")
           // currentScore = 0;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Damage(10);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

        if (other.gameObject.tag == "Grenade")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Damage(5);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

        if (other.gameObject.tag == "Knife")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Damage(5);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

        if (other.gameObject.tag == "Heal")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Heal(5);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

        if (other.gameObject.tag == "Enemy 2" && this.gameObject.tag == "Player")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            this.healthSystem.Damage(5);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

    }



    void onTriggerStay(Collider other)
    {

        if (other.tag == "Heal")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Heal(100);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }

        if (other.tag == "Knife")
        {
            // healthBar.Setup(healthSystem);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
            healthSystem.Damage(5);
            Debug.Log("Health = " + healthSystem.GetHealthPercent());
        }
    }

    private void HandleScore()
    {
        //GameObject.Find("Player").GetComponent<Player>().score += 10;

            Debug.Log(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().score);
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().ScoreInc();

    }


    // Update is called once per frame
    void Update()
    {
        //GameObject sphere = GameObject.Find("Enemy 2(Clone)/Sphere");
        HealthBar[] obj = this.gameObject.GetComponentsInChildren<HealthBar>();

        if(obj.Length == 2)
        {
            //Destroy(obj[0].gameObject);
        }

       if(healthSystem.GetHealth() == 0 && this.tag != "Player")
        {
            if (flag == true)
            {
                HandleScore();
                flag = false;
                //this.Destroy();
                //this.transform.parent.gameObject.GetComponentInChildren<HealthBar>().Setup(new HealthSystem(0));
                Destroy(this.gameObject);
                Destroy(this.transform.parent.gameObject);
                
            }

        }

       
    }
}

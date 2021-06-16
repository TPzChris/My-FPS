using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject map;
    public GameObject panel;
    public GameObject terrain;
    public string score;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeRemaining = 200;
        Debug.Log("TEST");
        terrain = GameObject.Find("TerrainB");
        panel = GameObject.Find("Canvas").transform.Find("ScorePanel").gameObject;
       
        
    } 

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            if(timeRemaining <= 0 || GameObject.FindGameObjectsWithTag("health")[0].GetComponent<Text>().text == "0")
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log(map.name);
                
                string ob = GameObject.FindGameObjectsWithTag("health")[0].GetComponent<Text>().text;
                Debug.Log("CHECK"+ob);
                map = GameObject.FindGameObjectsWithTag("Map")[0];
                //map.SetActive(false);
                GameObject.Find("EventSystem").GetComponent<audio>().lastMap = map.name;
                panel.SetActive(true);

                string s = GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;
                string reversed = "";
                for(int j = s.Length - 1; j >= 0; j--) {
                    reversed += s[j];
                }


                GameObject.FindGameObjectsWithTag("scoreT")[0].GetComponent<TMPro.TextMeshProUGUI>().text = reversed;
                Debug.Log("ZZZZZZZ"+GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text);// = GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;
                //Text s = (Text)GameObject.FindGameObjectsWithTag("scoreT")[0].GetComponent<Text>();
                //s.text = GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;
                //score = GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;
                //Text obs = GameObject.FindGameObjectsWithTag("scoreT")[0].GetComponent<Text>();
                //obs.text = GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;
                /*foreach (Text i in obs)
                {
                    Debug.Log(i.text);//GameObject.FindGameObjectsWithTag("scoretext")[0].GetComponent<Text>().text;

                }*/
                this.gameObject.SetActive(false);
                GetComponent<InstantiateEnemies>().enabled = false;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
               
            }
        }
    }

    public void ScoreMenu()
    {


        //GetComponent<InstantiateEnemies>().enabled = false;
        GameObject.FindGameObjectsWithTag("Player")[0].SetActive(false);
        Debug.Log("Timer_");
        //GameObject.FindGameObjectsWithTag("Map")[0].SetActive(false);
        //GameObject.FindGameObjectsWithTag("Map")[0].SetActive(true);

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
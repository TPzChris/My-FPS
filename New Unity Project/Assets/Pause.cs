using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    public bool paused = false;
    void Start()
    {
        PausePanel.SetActive(false);
    }
    void Update()
    {
        if (!paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }

            //paused = !paused;
        }
    }
    public void PauseGame()
    {
        GetComponent<InstantiateEnemies>().enabled = false;
        //GetComponent<AutomaticGunScriptLPFP>().enabled = false;
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy 21");
        foreach (GameObject e in enemies)
        {
            e.GetComponent<MoveTowardsMe>().speed = 0f; 
        }

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PausePanel.SetActive(true);
        paused = !paused;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {

        //enable the scripts again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PausePanel.SetActive(false);

        Time.timeScale = 1;
        
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy 21");
        foreach (GameObject e in enemies)
        {
            //GameObject f = GameObject.Find(e.gameObject.name + "/Sphere");
            e.GetComponent<MoveTowardsMe>().speed = 0.1f;
            
        }
        GetComponent<InstantiateEnemies>().enabled = true;
        //GetComponent<AutomaticGunScriptLPFP>().enabled = true;
        paused = !paused;
    }
}

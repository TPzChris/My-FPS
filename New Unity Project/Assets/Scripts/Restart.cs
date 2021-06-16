using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class Restart : MonoBehaviour
{
    public GameObject prefab;
    
    void Start()
    {
        //scene = SceneManager.GetActiveScene(); 
        RestartGame();
    }

    public void RestartGame()
    {
        Debug.Log("RESTART GAME");
        //Debug.Log(GetComponent<Backup>().defaultPos[0]);
        //GameObject.Find("Player").transform.position = GetComponent<Backup>().defaultPos[0];
        //Debug.Log(GameObject.Find("Player").transform.position);
        //GameObject.Find("Player").transform.position = new Vector3(Random.Range(250, 700), 20, Random.Range(50, 450));

        //Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy 21");
        foreach (GameObject e in enemies)
        {
            //GameObject f = GameObject.Find(e.gameObject.name + "/Sphere");
            e.SetActive(false);

        }
        //GetComponent<InstantiateEnemies>().enabled = true;
        //this.gameObject.GetComponent<Timer>().timeRemaining = 15;
        //this.gameObject.SetActive(false); 
        //GameObject.FindGameObjectsWithTag("Player")[0].SetActive(false);
        GameObject i = Instantiate(prefab, new Vector3(Random.Range(250, 700), 30, Random.Range(50, 450)), Quaternion.identity);
        Debug.Log(i.GetComponent<HealthBar>());//.Setup(new HealthSystem(100));

        i.GetComponent<GameHandler>().enabled = true;

        i.SetActive(true);
        Debug.Log("dddddddddd" + i.transform.position);
        Time.timeScale = 1;


        if(GameObject.FindGameObjectsWithTag("Player")[0].name == "Player(Clone)")
        {
            GameObject.Find("Restart").GetComponent<Button>().onClick.AddListener(TaskOnClick);
            GameObject.Find("Back").GetComponent<Button>().onClick.AddListener(TaskOnClickBack);
            
        }

        /*
        GameObject[] tele = GameObject.FindGameObjectsWithTag("Teleport");

        GameObject[] t;
        foreach (GameObject j in tele)
        {
            Debug.Log("ffff " + j.name);
            j.GetComponent<Teleport>().enabled = false;
            j.GetComponent<Teleport>().enabled = true;
        }
        */

        GameObject[] tele = GameObject.FindGameObjectsWithTag("Teleport2");

        
        foreach (GameObject j in tele)
        {
            Debug.Log("ffff " + j.name);
            j.GetComponent<CustomTeleporter>().enabled = false;
            j.GetComponent<CustomTeleporter>().enabled = true;
        }

    }

    public void AppQuit()
    {
        GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(TaskOnClickQuit);
    }

    public void TaskOnClick()
    {
        GameObject.Find("EventSystem").GetComponent<Timer>().ScoreMenu();
        GameObject.Find("EventSystem").GetComponent<Restart>().RestartGame();
        GameObject.Find("EventSystem").GetComponent<audio>().ChooseAudio();
    }

    public void TaskOnClickBack()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].SetActive(false);
        GameObject.Find("Canvas").transform.Find("MainPanel").gameObject.SetActive(true);
    }

    public void TaskOnClickQuit()
    {
        Application.Quit();
    }
}

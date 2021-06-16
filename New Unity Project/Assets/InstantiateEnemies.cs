using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    private int noEnemies = 0;
    private GameObject s;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        //prefab = GameObject.Find("Enemy 2");

        StartCoroutine(StartInstantiateTimer());

        
    }

    void PlaceObjects(GameObject prefab, GameObject player, GameObject s)
    {
        s = Instantiate(prefab, GeneratedPosition(player), Quaternion.identity);
        //s.GetComponent<HealthBar>().Setup(new HealthSystem(100));
    }

    Vector3 GeneratedPosition(GameObject t)
    {
        float x, y, z;
        x = t.transform.position.x + Random.Range(-30, 30);
        y = t.transform.position.y + Random.Range(0, 30);
        z = t.transform.position.z + Random.Range(-30, 30);
        return new Vector3(x, y, z);
    }

    private IEnumerator InstantiateTimer()
    {
        //Wait set amount of time
        yield return new WaitForSeconds(2f);
        
        PlaceObjects(prefab, player, s);
        
        //destroy(GameObject.Find(s.name + "/Sphere/HealthBar(Clone)"));
        Debug.Log("noEnemies (2) = " + noEnemies);
        noEnemies++;
        if (noEnemies < 100)
        StartCoroutine(InstantiateTimer());
    }

    private IEnumerator StartInstantiateTimer()
    {
        //Wait set amount of time
        yield return new WaitForSeconds(10);

        for (int i = 0; i < 10; i++)
        {
            PlaceObjects(prefab, player, s);
            noEnemies++;
            Debug.Log("noEnemies = " + noEnemies);
        }
        StartCoroutine(InstantiateTimer());
    }


    // Update is called once per frame
    void Update()
    {
        //Instantiate(target, Random.insideUnitSphere * radius + transform.position, Random.rotation);
    }
}

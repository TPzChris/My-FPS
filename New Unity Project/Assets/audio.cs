using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip m1;
    public AudioClip m2;

    public string lastMap;

    void Start()
    {
        audioSource.Play();
        Debug.Log("Sound");
    }

    public void SetAudio1()
    {
        GameObject o = GameObject.FindGameObjectsWithTag("Player")[0];
        o.GetComponent<AudioSource>().clip = m1;
        o.GetComponent<AudioSource>().Play();
        /*
        GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");

        foreach(GameObject map in maps)
        {
            if(map.name == "Map 1")
            {
                o.GetComponent<AudioSource>().clip = m1;
            }
            else if (map.name == "Map 2")
            {
                o.GetComponent<AudioSource>().clip = m2;
            }
        }
        */
    }

    public void SetAudio2()
    {
        GameObject o = GameObject.FindGameObjectsWithTag("Player")[0];
        o.GetComponent<AudioSource>().clip = m2;
        o.GetComponent<AudioSource>().Play();
    }


    public void ChooseAudio()
    {
        GameObject.Find(lastMap).SetActive(true);
        if (lastMap == "MAP 1") this.gameObject.GetComponent<audio>().SetAudio1();
        if (lastMap == "MAP 2") this.gameObject.GetComponent<audio>().SetAudio2();
    }

    public void SetLastMap(string lastMap)
    {
        this.lastMap = lastMap;
    }
}
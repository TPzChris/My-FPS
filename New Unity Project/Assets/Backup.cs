using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup : MonoBehaviour
{
    public Vector3[] defaultPos;
    public Vector3[] defaultScale;
    public Quaternion[] defaultRot;

    public Transform[] models;

    void Start()
    {
        //Call to back up the Transform before moving, scaling or rotating the GameObject
        backUpTransform();
    }

    void backUpTransform()
    {
        //Find GameObjects with Model tag
        GameObject[] tempModels = GameObject.FindGameObjectsWithTag("Player");

        //Create pos, scale and rot, Transform array size based on sixe of Objects found
        defaultPos = new Vector3[tempModels.Length];
        defaultScale = new Vector3[tempModels.Length];
        defaultRot = new Quaternion[tempModels.Length];

        models = new Transform[tempModels.Length];

        //Get original the pos, scale and rot of each Object on the transform
        for (int i = 0; i < tempModels.Length; i++)
        {
            models[i] = tempModels[i].GetComponent<Transform>();

            defaultPos[i] = models[i].position;
            defaultScale[i] = models[i].localScale;
            defaultRot[i] = models[i].rotation;

            
        }


    }



    // Update is called once per frame
    void Update()
    {
       
    }
}

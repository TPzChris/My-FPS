using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutiner : MonoBehaviour
{
    public IEnumerator TeleportTimer(int k)
    {
        k = 1;
        //Debug.Log("in corutina k = " + k);
        yield return new WaitForSeconds(2);

    }

    
}

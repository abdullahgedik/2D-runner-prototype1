using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator RandomGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
        }
    }
}

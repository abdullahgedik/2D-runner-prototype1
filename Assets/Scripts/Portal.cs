using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Vector2.Distance(player.transform.position, transform.position) > 0.75f)
        {
            player.transform.position = destination.transform.position;
        }
        
    }
}

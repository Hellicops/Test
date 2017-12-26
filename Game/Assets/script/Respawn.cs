using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private BoxCollider2D Collider;
    private void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        unit unit = collider.GetComponent<unit>();
        if(unit && unit is player)
        {
            Collider.enabled = false;
        }
    }

}

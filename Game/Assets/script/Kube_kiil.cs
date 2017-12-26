using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kube_kiil : unit
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        unit unit = collider.GetComponent<unit>();
        pairos pairos = collider.GetComponent<pairos>();

        if (unit && unit is player)
        {
            unit.ResivDameg();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_learn : unit
{
    private Vector3 position;
    public Money money;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        unit unit = collider.GetComponent<unit>();
        pairos pairos = collider.GetComponent<pairos>();
        Fly_kik krik = collider.GetComponent<Fly_kik>();

        if (unit && unit is player && !krik)
        {
            GameObject Player = collider.gameObject;
            unit.ResivDameg();
        }
        if (pairos)
        {
            Destroy(gameObject);
        }
        if (krik)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        position = transform.position;
        position = new Vector3(transform.position.x,transform.position.y + 1f);
    }

    private void OnDestroy()
    {
        Instantiate(money, position, transform.rotation);
    }
}

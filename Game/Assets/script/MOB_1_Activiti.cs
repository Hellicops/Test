using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB_1_Activiti : unit
{
    private SpriteRenderer sprite;
    [SerializeField]
    public GameObject PL;
    [SerializeField]
    public GameObject GG;
    private float spead = 3f;
    private bool key = false;
    private BoxCollider2D collid;

    private void Awake()
    {
        sprite = GG.GetComponentInChildren<SpriteRenderer>();
        collid = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject unit = collider.gameObject;
        pairos pairos = collider.GetComponent<pairos>();
        if (unit == PL)
        {
            key = true;
            collid.enabled = false;
        }
    }
    private void Update()
    {
        if (PL.GetComponentInChildren<SpriteRenderer>().enabled == false)
        {
            transform.position = transform.position;
            collid.enabled = true;
            key = false;
        }
        else
        {
            if (PL)
            {
                if (key == true)
                {
                    if (GG.transform.position.x == PL.transform.position.x - 1.0f || GG.transform.position.x == PL.transform.position.x + 1.0f)
                    {

                    }
                    else
                    { 
                        if (GG.transform.position.x < PL.transform.position.x)
                        {
                            GG.transform.Translate(Vector3.right * spead * Time.deltaTime);
                            sprite.flipX = false;
                            transform.position = transform.position;
                        }
                        if (GG.transform.position.x > PL.transform.position.x)
                        {
                            GG.transform.Translate(Vector3.left * spead * Time.deltaTime);
                            sprite.flipX = true;
                            transform.position = transform.position;
                        }
                    }
                }
            }
        }
    }
}
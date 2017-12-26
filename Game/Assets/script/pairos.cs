using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pairos : MonoBehaviour
{
    private float spead = 10f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private SpriteRenderer sprate;
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private bool isGroun = false;
    private void Awake()
    {
        sprate = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, 4.0F);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.01F);
        isGroun = collider.Length > 1;
        if (isGroun)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        unit unit = collider.GetComponent<unit>();
        if (unit && !unit.GetComponent<player>())
        {
            Destroy(gameObject);
        }
    }
   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB_2 : unit
{
    private float timer = 0;
    new private Rigidbody2D rigidbody;
    private Transform Position;
    [SerializeField]
    private GameObject PL;
    private float Hp;
    private SpriteRenderer sprite;
    public pairos Mpairos;
    void Awake()
    {
        Hp = 100;
        rigidbody = GetComponent<Rigidbody2D>();
        Position = GetComponent<Transform>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {

        if (Hp <= 0f)
        {
            Destroy(gameObject);
        }
        timer++;
        if (timer == 100 || timer == 120)
        {
            Vector3 position = transform.position;
            if (sprite.flipX)
            {
                position.y = position.y + 0.75F;
                position.x = position.x - 1.5F;
                pairos newpairos = Instantiate(Mpairos, position, Mpairos.transform.rotation) as pairos;
                newpairos.Direction = newpairos.transform.right * (sprite.flipX ? -1.0F : 1.0F);
                newpairos.Parent = gameObject;
            }
            else
            {
                position.y = position.y + 0.75F;
                position.x = position.x + 1.5F;
                pairos newpairos = Instantiate(Mpairos, position, Mpairos.transform.rotation) as pairos;
                newpairos.Direction = newpairos.transform.right * (sprite.flipX ? -1.0F : 1.0F);
                newpairos.Parent = gameObject;
            }
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        pairos pairos = collider.GetComponent<pairos>();
        Fly_kik Fly_kik = collider.GetComponent<Fly_kik>();
        unit unit = collider.GetComponent<unit>();
        if (pairos)
        {
            ResivDameg();
        }
        if (Fly_kik)
        {
            ResivDameg();
        }
    }

    public override void ResivDameg()
    {
        Hp = (Hp - 20F);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 3.0F, ForceMode2D.Impulse);
        if (transform.position.x < PL.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y);
        }
    }
}

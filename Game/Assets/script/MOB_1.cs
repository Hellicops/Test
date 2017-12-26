using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB_1: MOB_1_Activiti
{
    new private Rigidbody2D rigidbody;
    private Transform Position;
    private float Hp = 100f;
    public Money money;
    private Vector3 position;
    private Fly_kik GG;
    private Animator animator;
    private EdgeCollider2D edcol;
    private int timer = 0;
    private bool start = false;
    private bool flag = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Position = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        edcol = GetComponent<EdgeCollider2D>();
    }
    private CharState_Mob_1 State
    {
        get { return (CharState_Mob_1)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        pairos pairos = collider.GetComponent<pairos>();
        Fly_kik Fly_kik = collider.GetComponent<Fly_kik>();
        unit unit = collider.GetComponent<unit>();
        if (unit && unit is player && !Fly_kik && !flag )
        {
            edcol.enabled = false;
            flag = true;
            State = CharState_Mob_1.Ataka;
            start = true;

        }
        if (pairos)
        {
            ResivDameg();
        }
        if (Fly_kik)
        {
            ResivDameg();
            GG = Fly_kik;

        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        unit unit = collider.GetComponent<unit>();
        pairos pairos = collider.GetComponent<pairos>();
        Fly_kik Fly_kik = collider.GetComponent<Fly_kik>();

        if (unit && unit is player && !Fly_kik && flag  )
        {

            unit.ResivDameg(); 
            if(transform.position.x>unit.transform.position.x)
            {
                unit.transform.position = new Vector3(unit.transform.position.x - 3f, unit.transform.position.y);
            }
            if (transform.position.x < unit.transform.position.x)
            {
                unit.transform.position = new Vector3(unit.transform.position.x + 3f, unit.transform.position.y);
            }
          
        }
    }
    public override void ResivDameg()
    {
        Hp = (Hp - 20F);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 3.0F, ForceMode2D.Impulse);
        if(transform.position.x < PL.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 1f , transform.position.y);
        }

    }
    private void Update()
    {
        if (Hp <= 0f)
        {
            Destroy(gameObject);
        }
        position = transform.position;
        position = new Vector3(transform.position.x, transform.position.y + 1f);
        if (start == true)
        {
            timer++;
            if (timer == 110)
            {
                State = CharState_Mob_1.run;
                timer = 0;
                start = false;
                flag = false;
                edcol.enabled = true;
            }
        }
        
            
        
    }

    private void OnDestroy()
    {
        Instantiate(money, position, transform.rotation);
    }
}
public enum CharState_Mob_1
{
    run,
    Ataka
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.UI;


public class player : unit
{

    [SerializeField]
    private float spead = 5.0f;
    [SerializeField]
    private float JumpUp = 25.0f;
    [SerializeField]
    public pairos pairos;

    private bool isGroun = false;
    private Vector3 position;
    private bool KJostik = false;
    private bool KJostik_2 = false;
    public player parent;
    private int timer_1 = 150;
    private int timer_2 = 240;



    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Animator animator;
    private CircleCollider2D CirColiider;
    private PolygonCollider2D CirColiider_1;
    private Vector3 NRespawn;

    public Slider HpS;
    public int Hp;

    public Slider MpS;
    public float Mp;

    public Slider EpS;
    public float Ep;
    public int Lvl;
    public int coin = 0;
    public AudioSource sound;
    public AudioSource sound_damage;
    public AudioSource sound_die;
    public AudioSource fire;

    public static bool Kik = false;

    void OnGUI()
    {
        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 52;
        styleTime.normal.textColor = Color.black;
        GUI.Box(new Rect(1800, 75, 500, 300), "" + coin, styleTime);

    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        CirColiider = GetComponentInChildren<CircleCollider2D>();
        CirColiider_1 = GetComponentInChildren<PolygonCollider2D>();
    }

    private void Start()
    {
        Hp = 100;
        Mp = 60;
        Ep = 0;
    }


    private void FixedUpdate()
    {
        CheckGround();


    }

    private void Update()

    {
        if (KJostik == false)
        {
            //===================Жизни================================================
            HpS.value = Hp;
            if (Hp >= 100)
            {
                Hp = 100;
            }
            if (Hp <= 0)
            {
                Hp = 0;
                sound_die.Play();
                State = CharState.die;
                KJostik = true;
            }

            //=====================================================================

            //===================Энергия ================================================
            MpS.value = Mp;
            if (Mp >= 60)
            {
                Mp = 60;
            }
            if (Mp <= 0)
            {
                Mp = 0;
            }
            if (isGroun) { State = CharState.Item; }
            if (Mp < 60)
            {
                Mp = Mp + 0.05F;
            }

            //=====================================================================

            //==========================Опыт=======================================

            EpS.value = Ep;
            if (Ep >= 100)
            {
                Ep = 0;
                Lvl++;
            }
            if (Ep < 0)
            {
                Ep = 100;
                Lvl--;
            }

            //=====================================================================

            // =====================Джостик и кнопки ===================================================
            if (KJostik == false)
            {

                position = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"), 0f);
                if (position.x < 0 || position.x > 0)
                {
                    Run();
                }
                if (position.y > 0)
                {
                    Air();
                }
                if (CnInputManager.GetButtonUp("Attac_1"))
                {
                    Fly_kik();

                }
                if (CnInputManager.GetButtonDown("Attac_2"))
                {
                    if (Mp >= 20)
                    {
                        State = CharState.pairos;
                        fire.Play();
                        Shoot();
                        Mp = Mp - 20;
                    }
                }
            }
        }
        //===========================================================================================
        else
        {
            timer_2--;
            if (timer_2 == 100)
            {
                sprite.enabled = false;
                transform.position = NRespawn;
            }
            if (timer_2 == 0)
            {
                sprite.enabled = true;
                Hp = 100;
                KJostik = false;
                timer_2 = 240;
            }
        }
    }
 

    private CharState State
    {
        get{return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public override void ResivDameg()
    {
        if (Hp > 0)
        {
            Hp = (Hp - 20);
            sound_damage.Play();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 45F, ForceMode2D.Impulse);
            transform.position += -position * Time.deltaTime * 65F;

        }
        else
        {
            State = CharState.die;
        }
    }


    public void Run()
    {
        Vector3 direction = transform.right * CnInputManager.GetAxis("Horizontal");
        transform.position += position * Time.deltaTime * spead;
        sprite.flipX = direction.x < 0f;
        if (isGroun) { State = CharState.run; }
    }
    public void Air()
    {
        rigidbody.AddForce(transform.up * JumpUp, ForceMode2D.Impulse);
    }
    public void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        isGroun = collider.Length > 1;
        if (!isGroun)
        {
            State = CharState.air;
        }
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        if (sprite.flipX)
        {
            position.y = position.y + 0.75F;
            position.x = position.x - 1.5F;
            pairos newpairos = Instantiate(pairos, position, pairos.transform.rotation) as pairos;
            newpairos.Direction = newpairos.transform.right * (sprite.flipX ? -1.0F : 1.0F);
            newpairos.Parent = gameObject;
        }
        else
        {
            position.y = position.y + 0.75F;
            position.x = position.x + 1.5F;
            pairos newpairos = Instantiate(pairos, position, pairos.transform.rotation) as pairos;
            newpairos.Direction = newpairos.transform.right * (sprite.flipX ? -1.0F : 1.0F);
            newpairos.Parent = gameObject;
        }
    }
    private void Fly_kik()
    {
        if (sprite.flipX == true)
        {
            State = CharState.Fly_kik_l;
        }
        else
        {
            State = CharState.Fly_kik_r;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Respawn respawn = collider.GetComponent<Respawn>();
        Money money = collider.GetComponent<Money>();
        GameObject Money = collider.gameObject;
        experiense experiense = collider.GetComponent<experiense>();
        GameObject Experiense = collider.gameObject;
        pairos pairos = collider.GetComponent<pairos>();
        SpriteRenderer pairos_s = collider.GetComponentInChildren<SpriteRenderer>();
        if (money)
        {
            Destroy(Money);
            sound.Play();
            coin++;
        }
        if (experiense)
        {
            Ep += 20;
            Destroy(Experiense);
            sound.Play();
        }
        if (respawn)
        {
            GameObject NewRespawn = collider.gameObject;
            NRespawn = NewRespawn.transform.position;
        }
        if (pairos)
        {
            ResivDameg();
            Destroy(pairos);
            pairos_s.enabled = false;
        }
        
    }
}

public enum CharState
{
    Item,
    run,
    air,
    pairos,
    Fly_kik_l,
    die,
    Fly_kik_r
}


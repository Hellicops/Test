/// <summary>
/// Skills.
/// Вешается на персонажа
/// Добавляет меню прокачки скилов
/// </summary>
using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour
{

    public GUISkin mySkin;

    private int HP = 1;
    private int Mana = 1;
    private int Power = 1;

    private int _curHP;
    private int _curMana;
    private int _curPower;

    public int Health;
    public int CMana;
    public int Damage;

    public int skill;
    private int _curSkill;
    public int LVL;
    private int curLVL;

    private bool boolSkill;     // Кнопки прокачки
    private bool _visable = false;  //Окно прокачки

    private PlayerStats ps;

    // Use this for initialization
    void Start()
    {
        curLVL = LVL;

        _curHP = HP;
        _curMana = Mana;
        _curPower = Power;

        ps = GameObject.Find("Player").GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.I)) _visable = true;

        if (curLVL != LVL)
        {
            skill += 1;
            _curSkill = skill;
            curLVL = LVL;
        }

        if (skill != 0) boolSkill = true;


    }

    void OnGUI()
    {
        if (_visable)
        {
            GUI.skin = mySkin;

            //фон
            GUI.Box(new Rect(510, 10, 900, 1000), " ", GUI.skin.GetStyle("fon"));

            //надписи
            GUI.Label(new Rect(830, 25, 600, 800), "Parameters", GUI.skin.GetStyle("Text"));
            GUI.Label(new Rect(750, 300, 600, 800), "Curent parameters", GUI.skin.GetStyle("Text"));

            GUI.Label(new Rect(560, 710, 600, 800), "Skills:", GUI.skin.GetStyle("Text"));
            GUI.Label(new Rect(700, 710, 600, 800), skill.ToString(), GUI.skin.GetStyle("Text"));

            GUI.Label(new Rect(560, 80, 600, 800), "HP", GUI.skin.GetStyle("Text"));         // Здоровье
            GUI.Label(new Rect(560, 130, 600, 800), "Mana", GUI.skin.GetStyle("Text"));      // Мана
            GUI.Label(new Rect(560, 180, 600, 800), "Power", GUI.skin.GetStyle("Text"));     // Сила
           

            GUI.Label(new Rect(900, 80, 600, 800), HP.ToString(), GUI.skin.GetStyle("Text"));           // Здоровье
            GUI.Label(new Rect(900, 130, 600, 800), Mana.ToString(), GUI.skin.GetStyle("Text"));        // Мана
            GUI.Label(new Rect(900, 180, 600, 800), Power.ToString(), GUI.skin.GetStyle("Text"));       // Сила

            GUI.Label(new Rect(560, 360, 600, 800), "Health:", GUI.skin.GetStyle("Text"));      // Здоровье
            GUI.Label(new Rect(560, 410, 600, 800), "Mana:", GUI.skin.GetStyle("Text"));        // Мана
            GUI.Label(new Rect(560, 460, 600, 800), "Damage:", GUI.skin.GetStyle("Text"));      // Урон


            Health = HP * 30;
            CMana = Mana * 30;
            Damage = Power * 10;

            GUI.Label(new Rect(900, 360, 600, 800), Health.ToString(), GUI.skin.GetStyle("Text"));      // Здоровье
            GUI.Label(new Rect(900, 410, 600, 800), CMana.ToString(), GUI.skin.GetStyle("Text"));       // Мана
            GUI.Label(new Rect(900, 460, 600, 800), Damage.ToString(), GUI.skin.GetStyle("Text"));      // Урон


            //кнопки
            if (boolSkill)
            {
                // Здоровье
                if (skill != 0)
                {
                    if (GUI.Button(new Rect(720, 83, 45, 45), " ", GUI.skin.GetStyle("+")))
                    {
                        skill -= 1;
                        HP += 1;
                    }
                }
                if (HP != _curHP)
                {
                    if (GUI.Button(new Rect(780, 83, 45, 45), " ", GUI.skin.GetStyle("-")))
                    {
                        skill += 1;
                        HP -= 1;
                    }
                }

                // Сила
                if (skill != 0)
                {
                    if (GUI.Button(new Rect(720, 183, 45, 45), " ", GUI.skin.GetStyle("+")))
                    {
                        skill -= 1;
                        Power += 1;
                    }
                }
                if (Power != _curPower)
                {
                    if (GUI.Button(new Rect(780, 183, 45, 45), " ", GUI.skin.GetStyle("-")))
                    {
                        skill += 1;
                        Power -= 1;
                    }
                }

                //Мана
                if (skill != 0)
                {
                    if (GUI.Button(new Rect(720, 133, 45, 45), " ", GUI.skin.GetStyle("+")))
                    {
                        skill -= 1;
                        Mana += 1;
                    }
                }
                if (Mana != _curMana)
                {
                    if (GUI.Button(new Rect(780, 133, 45, 45), " ", GUI.skin.GetStyle("-")))
                    {
                        skill += 1;
                        Mana -= 1;
                    }
                }
            }
            if (GUI.Button(new Rect(1000, 850, 250, 100), " ", GUI.skin.GetStyle("Ok")))
            {
                _curHP = HP;
                _curMana = Mana;
                _curPower = Power;
                _curSkill = skill;
                if (ps != null)
                {
                    ps.MaxHealth = Health;
                    ps.MaxMana = CMana;
                }
                _visable = false;
            }
            if (GUI.Button(new Rect(650, 850, 250, 100), " ", GUI.skin.GetStyle("No")))
            {
                HP = _curHP;
                Mana = _curMana;
                Power = _curPower;
                skill = _curSkill;
                _visable = false;
            }
        }
    }
}
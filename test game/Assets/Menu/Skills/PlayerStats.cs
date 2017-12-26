/// <summary>
/// Player stats.
/// Хранит данные о игроке
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	
	//public int LVL;
	//public GameObject Target;
	public int MaxHealth; // Максимальное количество здоровья
	public int CurHealth; // Текущее количество здоровья
	public int MaxMana; // Максимально количество маны
	public int CurMana; // Текущее количество маны

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(MaxHealth < CurHealth) CurHealth = MaxHealth;
		if(MaxMana < CurMana) CurMana = MaxMana;
	}
}

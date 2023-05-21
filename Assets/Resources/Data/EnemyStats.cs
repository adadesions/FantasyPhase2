using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Stats/Enemy")]
public class EnemyStats : ScriptableObject
{
	// Fields
	public int Health;
	public int MaxHealth;
	public int MP;
	public int MaxMP;
	public float Stamina;
	public int Armor;
	public int Damage;
	public int Level;
	public int Agility;
	public string EnemyName;
	public int XP;
}

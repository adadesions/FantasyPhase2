using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Stats/Player")]
public class PlayerStats : ScriptableObject
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
	public int XP;
	public string PlayerName;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
	[Header("UI BattleScene")]
	public int health;
	public int maxHealth;
	public int mp;
	public int maxMP;
	public float stamina;

	[Header("Basic Stats")]
	public int armor;
	public int damage;
	public int level;
	public int agility;
}

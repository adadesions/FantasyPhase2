using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
	[Header("UI BattleScene")]
	public string playerName;
	public int health;
	public int maxHealth;
	public int mp;
	public int maxMP;
	public float stamina;

	[Header("Basic Stats")]
	public int armor;
	public int damage;
	public int level;
	public int experience;

}

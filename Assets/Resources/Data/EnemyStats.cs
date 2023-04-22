using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Stats/Enemy")]
public class EnemyStats : CharacterStats
{
	public string enemyName;
	public int xp;
}

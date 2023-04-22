using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Stats/Player")]
public class PlayerStats : CharacterStats
{
	public string playerName;
	public int experience;
}
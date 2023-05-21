using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseState
{
	int Health { get; set; }
	int MaxHealth { get; set; }
	int MP { get; set; }
	int MaxMP { get; set; }
	float Stamina { get; set; }

	int Armor { get; set; }
	int Damage { get; set; }
	int Level { get; set; }
	int Agility { get; set; }
}

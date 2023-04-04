using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class EnemyController : MonoBehaviour
	{
		[Header("Status")]
		[SerializeField] float m_maxHealth = 100;
		[SerializeField] float m_curHealth = 100;

		[SerializeField] float m_attack = 50;
		[SerializeField] float m_defense = 20;

		// Agility 0-100
		[SerializeField] float m_agility = 10;

		private bool m_isDead = false;

		public float CurHealth { get => m_curHealth; set => m_curHealth = value; }
		public float MaxHealth { get => m_maxHealth; set => m_maxHealth = value; }
		public bool IsDead { get => m_isDead; set => m_isDead = value; }

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void TakeDamage(int damage)
		{
			m_curHealth -= damage;

			if (m_curHealth <= 0) {
				m_curHealth = 0;
				OnDead();
			}
		}

		private void OnDead()
		{
			m_isDead = true;
			gameObject.SetActive(false);
			//Destroy(gameObject);
		}
	}
}
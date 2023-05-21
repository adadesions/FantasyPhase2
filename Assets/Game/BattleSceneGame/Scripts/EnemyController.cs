using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class EnemyController : MonoBehaviour
	{
		[Header("Status")]
		[SerializeField] EnemyStats m_enemyStats;

		private bool m_isDead = false;

		private int m_curHealth;
		public int CurHealth { get => m_curHealth; set => m_curHealth = value; }
		public int MaxHealth { get => m_enemyStats.MaxHealth; private set => m_enemyStats.MaxHealth = value; }
		public bool IsDead { get => m_isDead; set => m_isDead = value; }
		public EnemyStats EnemyStats { get => m_enemyStats; set => m_enemyStats = value; }

		private void Start()
		{
			m_curHealth = m_enemyStats.Health;
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
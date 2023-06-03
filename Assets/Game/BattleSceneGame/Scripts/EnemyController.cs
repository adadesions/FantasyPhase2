using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Jrpg.BattleScene
{
	public class EnemyController : MonoBehaviour, ITurner
	{
		[Header("Status")]
		[SerializeField] EnemyStats m_enemyStats;
		[SerializeField] bool m_isCurrentQueue = false;
		[SerializeField] Vector3 m_textOffset;
		private bool m_isDead = false;
		private int m_curHealth;
		private GameObject m_queueText;

		public int CurHealth { get => m_curHealth; set => m_curHealth = value; }
		public int MaxHealth { get => m_enemyStats.MaxHealth; private set => m_enemyStats.MaxHealth = value; }
		public bool IsDead { get => m_isDead; set => m_isDead = value; }
		public EnemyStats EnemyStats { get => m_enemyStats; set => m_enemyStats = value; }
		public bool IsCurrentQueue { get => m_isCurrentQueue; set => m_isCurrentQueue = value; }

		private void Start()
		{
			m_curHealth = m_enemyStats.Health;
			m_textOffset = new(9, 0.5f, 0);
			m_queueText = new GameObject("QueueText");
			m_queueText.transform.position = transform.position + m_textOffset;
			m_queueText.transform.SetParent(gameObject.transform);

			TextMeshPro textComp = m_queueText.AddComponent<TextMeshPro>();
			textComp.text = "HERE";
			textComp.fontSize = 4;
			m_queueText.SetActive(false);
		}

		//private void Update()
		//{
		//	m_queueText.transform.position = transform.position + m_textOffset;
		//}

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

		public void Pointing()
		{
			m_isCurrentQueue = true;
			m_queueText.SetActive(true);
			print(gameObject.name + " is pointing");
		}

		public void ReleasePointing()
		{
			m_isCurrentQueue = false;
			m_queueText.SetActive(false);
			print(gameObject.name + " is Release Pointing");
		}
	}
}
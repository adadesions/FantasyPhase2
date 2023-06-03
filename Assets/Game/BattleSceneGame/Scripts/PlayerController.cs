using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jrpg.BattleScene
{
	public class PlayerController : MonoBehaviour, ITurner, IHealth
	{
		[SerializeField] PlayerStats m_playerStats;
		private bool m_isCurrentQueue;
		private float m_maxHP;
		private float m_currentHP = 0f;

		public PlayerStats PlayerStats { get => m_playerStats; set => m_playerStats = value; }
		public float MaxHP { get => m_maxHP; set => m_maxHP = value; }
		public float CurrentHP { get => m_currentHP; set => m_currentHP = value; }

		// Start is called before the first frame update
		void Start()
		{
			m_maxHP = m_playerStats.MaxHealth;
			m_currentHP = m_playerStats.Health;
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void TakeDamage(float damage)
		{
			if (damage < 0) return;

			m_currentHP -= damage;

			print("CurHP: " + m_currentHP.ToString());

			if (m_currentHP < 0) {
				m_currentHP = 0;
			}

			SaveData();
			UIManager.Instance.PlayerPanel.UpdatePlayerPanel();
		}

		public void SaveData()
		{
			m_playerStats.Health = (int)m_currentHP;
		}


		public void Pointing()
		{
			m_isCurrentQueue = true;
			print(gameObject.name + " is pointing");
		}

		public void ReleasePointing()
		{
			m_isCurrentQueue = false;
			print(gameObject.name + " is Release Pointing");
		}
	}
}

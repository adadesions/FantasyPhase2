using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class EnemyAI : MonoBehaviour
	{
		private IHealth m_target;
		private EnemyController m_controller;
		private EnemyStats m_enemyStat;
		private bool m_isActiveAI = false;

		private bool m_isRelease = false;
		private float m_lastTimeAttack = 0.0f;

		// Start is called before the first frame update
		void Start()
		{
			m_target = PlayerManager.Instance.PlayersInScene[0].GetComponent<IHealth>();
			m_controller = GetComponent<EnemyController>();
			m_enemyStat = m_controller.EnemyStats;
		}

		// Update is called once per frame
		void Update()
		{
			// TODO: Delay for AI Attacking
			if (CheckIsAIActivate()) {
				AttackToTarget();
				DeactivateAI();
			}
		}

		private void DeactivateAI()
		{
			m_controller.ReleasePointing();
			TurnManager.Instance.NextQueue();
		}

		private void AttackToTarget()
		{
			m_target.TakeDamage(m_enemyStat.Damage);
		}

		private bool CheckIsAIActivate()
		{
			return m_controller.IsCurrentQueue;
		}
	}
}

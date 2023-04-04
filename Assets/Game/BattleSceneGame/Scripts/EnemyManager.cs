using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class EnemyManager : MonoBehaviour
	{
		private static EnemyManager m_instance;
		[SerializeField] Transform m_parentEnemyPositions;
		[SerializeField] List<GameObject> m_monstersAndPosition;

		private List<Transform> m_enemyPositions = new();

		public List<GameObject> MonstersAndPosition { get => m_monstersAndPosition; set => m_monstersAndPosition = value; }
		public static EnemyManager Instance { get => m_instance; set => m_instance = value; }


		private void Awake()
		{
			if (m_instance != null && m_instance != this) {
				Destroy(this);
				return;
			}

			m_instance = this;
		}

		// Start is called before the first frame update
		void Start()
		{
			InitEnemyPositions();
			SpawnEnemies();
		}

		private void SpawnEnemies()
		{
			for (int i = 0; i < MonstersAndPosition.Count; i++) {
				Instantiate(
					MonstersAndPosition[i],
					m_enemyPositions[i].localPosition,
					Quaternion.identity);
			}
		}

		private void InitEnemyPositions()
		{
			foreach (Transform pos in m_parentEnemyPositions) {
				m_enemyPositions.Add(pos);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
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
		private List<GameObject> m_enemyInScene = new();
		private Dictionary<string, GameObject> m_enemyLookupTable = new();

		public List<GameObject> MonstersAndPosition { get => m_monstersAndPosition; set => m_monstersAndPosition = value; }
		public static EnemyManager Instance { get => m_instance; set => m_instance = value; }
		public List<GameObject> EnemyInScene { get => m_enemyInScene; set => m_enemyInScene = value; }

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
			TurnManager.Instance.OnAddedCharacters(m_enemyLookupTable);
		}

		private void SpawnEnemies()
		{
			for (int i = 0; i < MonstersAndPosition.Count; i++) {
				GameObject enemyClone = Instantiate(
					MonstersAndPosition[i],
					m_enemyPositions[i].position,
					Quaternion.identity);
				enemyClone.transform.SetParent(m_parentEnemyPositions);
				m_enemyInScene.Add(enemyClone);

				// Add to lookup table with UUID
				System.Random random = new System.Random();
				string uuid = random.Next(0x1000, 0x10000).ToString("X4");
				m_enemyLookupTable.Add(uuid, enemyClone);
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
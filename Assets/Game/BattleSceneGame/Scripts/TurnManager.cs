using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Linq;

namespace Jrpg.BattleScene
{
	public class TurnManager : MonoBehaviour
	{
		private static TurnManager m_instance;
		private List<KeyValuePair<string, GameObject>> m_chractersInScene;
		private Queue<GameObject> m_playingQueue;
		private int latestCharacterCount = 0;

		public static TurnManager Instance { get => m_instance; set => m_instance = value; }

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
			m_chractersInScene = new();
			m_playingQueue = new();
		}

		// Update is called once per frame
		void Update()
		{
			QueueHandle();
		}

		private void QueueHandle()
		{
			if (m_chractersInScene.Count == latestCharacterCount)
				return;

			// Sorting
			m_chractersInScene.Sort(SortedByAgi());

			// Display Agi information
			foreach (KeyValuePair<string, GameObject> kvp in m_chractersInScene) {
				//print(kvp.Key.ToString() + ", " + kvp.Value.name.ToString());
				GameObject character = kvp.Value;
				String tag = character.tag;

				if (tag == "Player") {
					PlayerStats stats = character.GetComponent<PlayerController>().PlayerStats;
					print("Player Agi: " + stats.Agility);
				} else if (tag == "Enemy") {
					EnemyStats stats = character.GetComponent<EnemyController>().EnemyStats;
					print("Enemy Agi: " + stats.Agility);
				}
			}

			latestCharacterCount = m_chractersInScene.Count;

		}

		private static Comparison<KeyValuePair<string, GameObject>> SortedByAgi()
		{
			return (x, y) => x.Value.CompareTag("Player")
							? x.Value.GetComponent<PlayerController>().PlayerStats.Agility
							.CompareTo(CompareAgi(y))
							: x.Value.GetComponent<EnemyController>().EnemyStats.Agility
							.CompareTo(CompareAgi(y));
		}

		private static int CompareAgi(KeyValuePair<string, GameObject> y)
		{
			return y.Value.CompareTag("Player")
								? y.Value.GetComponent<PlayerController>().PlayerStats.Agility
								: y.Value.GetComponent<EnemyController>().EnemyStats.Agility;
		}

		public void OnAddedCharacters(Dictionary<string, GameObject> characters)
		{
			foreach (KeyValuePair<string, GameObject> kvp in characters) {
				m_chractersInScene.Add(kvp);
			}
		}
	}
}
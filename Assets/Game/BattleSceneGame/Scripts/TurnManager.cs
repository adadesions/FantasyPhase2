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
		private Dictionary<string, GameObject> m_chractersInScene;
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

			foreach (KeyValuePair<string, GameObject> kvp in m_chractersInScene) {
				print(kvp.Key.ToString() + ", " + kvp.Value.name.ToString());
			}

			//m_chractersInScene = m_chractersInScene.OrderBy(
			//	x => x.Value.GetComponent<>)

			latestCharacterCount = m_chractersInScene.Count;

		}

		public void OnAddedCharacters(Dictionary<string, GameObject> characters)
		{
			foreach (KeyValuePair<string, GameObject> kvp in characters) {
				m_chractersInScene.Add(kvp.Key, kvp.Value);
			}
		}
	}
}
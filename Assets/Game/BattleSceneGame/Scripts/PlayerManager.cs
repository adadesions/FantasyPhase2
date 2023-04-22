using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class PlayerManager : MonoBehaviour
	{
		private static PlayerManager m_instance;
		[SerializeField] Transform m_parentPlayerPositions;
		[SerializeField] List<GameObject> m_playerAndPosition;
		[SerializeField] List<PlayerStats> m_playerStatsList;

		private List<Transform> m_playerPositions = new();
		private List<GameObject> m_playersInScene = new();
		private int m_numberOfPlayers = 0;
		private Dictionary<string, GameObject> m_playerLookupTable = new();

		public List<GameObject> PlayerAndPosition { get => m_playerAndPosition; set => m_playerAndPosition = value; }
		public static PlayerManager Instance { get => m_instance; set => m_instance = value; }
		public List<GameObject> PlayersInScene { get => m_playersInScene; set => m_playersInScene = value; }
		public List<PlayerStats> PlayerStatsList { get => m_playerStatsList; set => m_playerStatsList = value; }
		public int NumberOfPlayers { get => m_numberOfPlayers; set => m_numberOfPlayers = value; }
		public Dictionary<string, GameObject> PlayerLookupTable { get => m_playerLookupTable; set => m_playerLookupTable = value; }

		private void Awake()
		{
			if (m_instance != null && m_instance != this) {
				Destroy(this);
				return;
			}

			m_instance = this;
			Init();
		}

		// Start is called before the first frame update
		void Start()
		{
			SpawnPlayers();
			TurnManager.Instance.OnAddedCharacters(m_playerLookupTable);
		}

		private void Init()
		{
			InitPlayerPositions();
			m_numberOfPlayers = m_playerStatsList.Count;
		}

		private void SpawnPlayers()
		{
			for (int i = 0; i < PlayerAndPosition.Count; i++) {
				GameObject playerClone = Instantiate(
					PlayerAndPosition[i],
					m_playerPositions[i].position,
					Quaternion.identity);

				playerClone.transform.SetParent(m_parentPlayerPositions);
				playerClone.name = m_playerStatsList[i].playerName;
				m_playersInScene.Add(playerClone);

				// Add to lookup table with UUID
				System.Random random = new System.Random();
				string uuid = random.Next(0x1000, 0x10000).ToString("X4");
				m_playerLookupTable.Add(uuid, playerClone);
			}
		}

		private void InitPlayerPositions()
		{
			foreach (Transform pos in m_parentPlayerPositions) {
				m_playerPositions.Add(pos);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}

	}
}
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

		private List<Transform> playerPositions = new();
		private List<GameObject> playersInScene = new();
		private int m_numberOfPlayers = 0;

		public List<GameObject> PlayerAndPosition { get => m_playerAndPosition; set => m_playerAndPosition = value; }
		public static PlayerManager Instance { get => m_instance; set => m_instance = value; }
		public List<GameObject> PlayersInScene { get => playersInScene; set => playersInScene = value; }
		public List<PlayerStats> PlayerStatsList { get => m_playerStatsList; set => m_playerStatsList = value; }
		public int NumberOfPlayers { get => m_numberOfPlayers; set => m_numberOfPlayers = value; }

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
					playerPositions[i].position,
					Quaternion.identity);

				playerClone.transform.SetParent(m_parentPlayerPositions);
				playerClone.name = m_playerStatsList[i].playerName;
				playersInScene.Add(playerClone);
			}
		}

		private void InitPlayerPositions()
		{
			foreach (Transform pos in m_parentPlayerPositions) {
				playerPositions.Add(pos);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}

	}
}
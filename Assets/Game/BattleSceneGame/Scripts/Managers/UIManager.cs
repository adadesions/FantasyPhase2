using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.BattleScene
{
	public class UIManager : MonoBehaviour
	{
		private static UIManager m_instance;
		private PlayerPanel m_playerPanel;

		public static UIManager Instance { get => m_instance; set => m_instance = value; }
		public PlayerPanel PlayerPanel { get => m_playerPanel; set => m_playerPanel = value; }

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
			m_playerPanel = GetComponent<PlayerPanel>();
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}

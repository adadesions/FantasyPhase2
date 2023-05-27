using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jrpg.BattleScene
{
	public class PlayerController : MonoBehaviour, ITurner
	{
		[SerializeField] PlayerStats m_playerStats;
		private bool m_isCurrentQueue;

		public PlayerStats PlayerStats { get => m_playerStats; set => m_playerStats = value; }

		public void Pointing()
		{
			m_isCurrentQueue = true;
			print(gameObject.name + " is pointing");
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}

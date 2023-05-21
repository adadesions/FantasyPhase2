using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jrpg.BattleScene
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] PlayerStats m_playerStats;

		public PlayerStats PlayerStats { get => m_playerStats; set => m_playerStats = value; }

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

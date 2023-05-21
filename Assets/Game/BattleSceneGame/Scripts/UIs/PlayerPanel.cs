using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Jrpg.BattleScene
{
	public class PlayerPanel : MonoBehaviour
	{
		[SerializeField] Transform m_partyPanel;

		// Start is called before the first frame update
		void Start()
		{
			InitPartyMembersName();
		}

		private void InitPartyMembersName()
		{
			int counter = 0;
			print(PlayerManager.Instance.NumberOfPlayers);
			foreach (Transform memberPanel in m_partyPanel) {
				if (!memberPanel.CompareTag("MemberPanel")) continue;
				if (counter >= PlayerManager.Instance.NumberOfPlayers) return;

				memberPanel.gameObject.SetActive(true);
				PlayerStats stats = PlayerManager.Instance.PlayerStatsList[counter];

				StatsFormatting(memberPanel, stats);

				counter++;
			}
		}

		private static void StatsFormatting(Transform memberPanel, PlayerStats stats)
		{
			foreach (Transform child in memberPanel) {
				TextMeshProUGUI textGUI = child.GetComponent<TextMeshProUGUI>();
				switch (child.name) {
					case "NameLabel":
						textGUI.text = stats.PlayerName;
						break;
					case "HPLabel":
						textGUI.text = string.Format("{0} / {1}", stats.Health, stats.MaxHealth);
						break;
					case "MPLabel":
						textGUI.text = string.Format("{0} / {1}", stats.MP, stats.MaxMP);
						break;
					case "StaminaLabel":
						child.GetComponent<Image>().fillAmount = stats.Stamina;
						break;
				}
			}
		}
	}
}
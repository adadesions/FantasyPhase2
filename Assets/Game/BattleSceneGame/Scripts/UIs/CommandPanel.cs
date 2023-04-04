using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Jrpg.BattleScene
{

	public class CommandPanel : MonoBehaviour
	{
		[SerializeField] GameObject m_prefabsEnemyNameUI;
		[SerializeField] GameObject m_commandPanel;

		[Header("Attack Command")]
		[SerializeField] GameObject m_popupAttackCommand;


		public void OnClickAttackCommand()
		{
			//m_commandPanel.SetActive(false);
			m_popupAttackCommand.SetActive(true);
			List<GameObject> enemyInScene = EnemyManager.Instance.MonstersAndPosition;

			foreach (GameObject enemy in enemyInScene) {
				GameObject enemyNameUI = Instantiate(
					m_prefabsEnemyNameUI,
					m_prefabsEnemyNameUI.transform.position,
					Quaternion.identity
				);

				enemyNameUI.
					transform.
					Find("Text").gameObject.
					GetComponent<TextMeshPro>()
					.text = enemy.name;

				enemyNameUI.transform.SetParent(m_popupAttackCommand.transform);
			}


		}
	}
}
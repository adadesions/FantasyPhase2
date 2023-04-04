using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
			m_popupAttackCommand.SetActive(true);
			List<GameObject> enemyReference = EnemyManager.Instance.MonstersAndPosition;
			List<GameObject> enemyInScene = EnemyManager.Instance.EnemyInScene;
			List<GameObject> enemyNameUI = new();
			int count = 0;

			foreach (Transform ui in m_popupAttackCommand.transform) {
				enemyNameUI.Add(ui.gameObject);
			}

			foreach (GameObject enemy in enemyReference) {
				TextMeshProUGUI ui = enemyNameUI[count].GetComponent<TextMeshProUGUI>();
				ui.text = enemy.name;

				bool isDead = enemyInScene[count].GetComponent<EnemyController>().IsDead;
				if (isDead) {
					enemyNameUI[count].GetComponent<Button>().interactable = false;
				}

				float maxHealth = enemyInScene[count].GetComponent<EnemyController>().MaxHealth;
				float curHealth = enemyInScene[count].GetComponent<EnemyController>().CurHealth;
				float value = curHealth / maxHealth;
				if (value > 0.5f) {
					ui.color = Color.white;
				} else if (value > 0.25f) {
					ui.color = Color.yellow;
				} else if (value > 0.0f) {
					ui.color = Color.red;
				} else {
					ui.color = Color.gray;
				}

				count++;
			}
		}

		public void OnClickEnemyName(int idx)
		{
			m_popupAttackCommand.SetActive(false);
			EnemyController enemyController =
				EnemyManager
				.Instance
				.EnemyInScene[idx]
				.GetComponent<EnemyController>();

			enemyController.TakeDamage(30);
		}
	}
}
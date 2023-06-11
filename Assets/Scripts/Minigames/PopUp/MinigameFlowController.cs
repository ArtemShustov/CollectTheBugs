using Game.UI.PanelSystem;
using UnityEngine;

namespace Game.Minigames.PopUp {
	public class MinigameFlowController: MonoBehaviour {
		[SerializeField] private PopUpFlow _flow;
		[SerializeField] private PanelSwitcher _globalUi;

		private void GameEnded() {
			_globalUi.ShowGameEnd();
		}

		private void OnEnable() {
			_flow.Ended += GameEnded;
			_flow.StartGame();
		}
		private void OnDisable() {
			_flow.Ended -= GameEnded;
		}
	}
}
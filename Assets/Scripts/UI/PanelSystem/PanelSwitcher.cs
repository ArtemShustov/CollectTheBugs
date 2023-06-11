using UnityEngine;

namespace Game.UI.PanelSystem {
	public class PanelSwitcher: MonoBehaviour {
		[SerializeField] private bool _startFromMenu = true;
		[SerializeField] private Panel _gamePanel;
		[SerializeField] private Panel _gameEndPanel;
		[SerializeField] private Panel _menuPanel;

		private Panel _current;

		public void ShowGameEnd() => ShowPanel(_gameEndPanel);
		public void ShowMenu() => ShowPanel(_menuPanel);
		public void ShowGame() => ShowPanel(_gamePanel);
		public void ShowPanel(Panel panel) {
			if (_current != null) {
				_current.Hide();
			}
			_current = panel;
			_current.Show();
		}

		private void OnEnable() {
			if (_startFromMenu) {
				foreach (RectTransform child in transform) {
					child.gameObject.SetActive(false);
				}
				ShowMenu();
			}
		}
	}
}
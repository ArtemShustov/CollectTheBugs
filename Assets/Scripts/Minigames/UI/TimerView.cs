using TMPro;
using UnityEngine;

namespace Game.Minigames.UI {
	public class TimerView: MonoBehaviour {
		[SerializeField] private string _pattern = "TimeLeft: {0}";
		[SerializeField] private Timer _timer;
		[SerializeField] private TMP_Text _label;

		private void UpdateLabel(int timer) {
			_label.text = string.Format(_pattern, timer);
		}

		private void OnEnable() {
			_timer.Changed += UpdateLabel;
			UpdateLabel(_timer.TimeLeft);
		}
		private void OnDisable() {
			_timer.Changed -= UpdateLabel;
		}
	}
}
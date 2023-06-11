using TMPro;
using UnityEngine;

namespace Game.Minigames.UI {
	public class ScoreView: MonoBehaviour {
		[SerializeField] private string _pattern = "Score: {0}";
		[SerializeField] private Score _score;
		[SerializeField] private TMP_Text _label;

		private void UpdateLabel(int score) {
			_label.text = string.Format(_pattern, score);
		}

		private void OnEnable() {
			_score.Changed += UpdateLabel;
			UpdateLabel(_score.Count);
		}
		private void OnDisable() {
			_score.Changed -= UpdateLabel;
		}
	}
}
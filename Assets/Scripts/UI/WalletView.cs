using TMPro;
using UnityEngine;

namespace Game.UI {
	public class WalletView: MonoBehaviour {
		[SerializeField] private string _pattern = "Wallet: {0}";
		[SerializeField] private Wallet _wallet;
		[SerializeField] private TMP_Text _label;

		private void UpdateLabel(int timer) {
			_label.text = string.Format(_pattern, timer);
		}

		private void OnEnable() {
			_wallet.Changed += UpdateLabel;
			UpdateLabel(_wallet.Count);
		}
		private void OnDisable() {
			_wallet.Changed -= UpdateLabel;
		}
	}
}
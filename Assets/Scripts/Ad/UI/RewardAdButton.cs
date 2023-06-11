using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ad.UI {
	public class RewardAdButton: MonoBehaviour {
		[SerializeField] private string _failText = "Unvalibale";
		[SerializeField] private string _claimedText = "Claimed";
		[SerializeField] private string _loadingText = "Loading";
		[Space]
		[SerializeField] private Button _button;
		[SerializeField] private TMP_Text _label;
		[SerializeField] private AdBonus _ad;

		public void ShowAd() {
			_ad.Show();
		}

		private void LockFailed() {
			_button.interactable = false;
			_label.text = _failText;
		}
		private void LockRewarded() {
			_button.interactable = false;
			_label.text = _claimedText;
		}
		private void Unlock() {
			_button.interactable = true;
			_label.text = $"+{_ad.BonusAmount}";
		}

		private void OnEnable() {
			_button.interactable = false;
			_label.text = _loadingText;
			_ad.Loaded += Unlock;
			_ad.Rewarded += LockRewarded;
			_ad.LoadFailed += LockFailed;
			if (_ad.IsLoaded == false) {
				_ad.Require();
			} else {
				Unlock();
			}
		}
		private void OnDisable() {
			_button.interactable = false;
			_label.text = _loadingText;
			_ad.Loaded -= Unlock;
			_ad.Rewarded -= LockRewarded;
			_ad.LoadFailed += LockFailed;
		}
	}
}
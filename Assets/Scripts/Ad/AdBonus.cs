using Game.Settings;
using System;
using UnityEngine;
using YandexMobileAds.Base;
using YandexMobileAds;
using System.Collections;

namespace Game.Ad {
	public class AdBonus: MonoBehaviour {
		[SerializeField] private Wallet _wallet;
		[Space]
		[SerializeField] private AdSettings _settings;

		private RewardedAd _ad;

		public int BonusAmount => _settings.AdBonus;
		public bool IsLoaded => _ad != null && _ad.IsLoaded();

		public event Action Loaded;
		public event Action LoadFailed;
		public event Action Rewarded;

		public void Require() {
			_ad = new RewardedAd(_settings.Token);
			_ad.OnRewardedAdFailedToLoad += HandleFail;
			_ad.OnRewardedAdFailedToShow += HandleFail;
			_ad.OnRewarded += RewardUser;
			StartCoroutine(WaitForLoad());
			AdRequest request = new AdRequest.Builder().Build();
			_ad.LoadAd(request);
		}
		public void Show() {
			if (_ad.IsLoaded()) {
				_ad.Show();
			}
		}

		private void RewardUser(object sender, Reward e) {
			_wallet.Add(_settings.AdBonus);
			Rewarded?.Invoke();
		}
		private void HandleFail(object sender, AdFailureEventArgs e) {
			StopCoroutine(WaitForLoad());
			LoadFailed?.Invoke();
		}
		private IEnumerator WaitForLoad() {
			while (_ad.IsLoaded() == false) {
				yield return new WaitForEndOfFrame();
			}
			Loaded?.Invoke();
		}
	}
}
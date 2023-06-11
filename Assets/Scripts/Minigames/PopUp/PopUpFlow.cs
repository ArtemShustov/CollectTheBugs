using Game.Settings;
using System;
using UnityEngine;

namespace Game.Minigames.PopUp {
	public class PopUpFlow: MonoBehaviour {
		[SerializeField] private Timer _timer;
		[SerializeField] private Score _score;
		[SerializeField] private PopUpPool _spawner;
		[SerializeField] private Wallet _wallet;
		[Space]
		[SerializeField] private PopUpMinigameSettings _settings;
		private bool _active = false;

		public event Action Started;
		public event Action Ended;

		public void StartGame() {
			if (_active) {
				return;
			}
			_active = true;

			_score.Reset();
			_timer.Ended += StopGame;
			_timer.StartCountdown(_settings.RoundTime);
			_spawner.SomeClicked += AddScorePoints;
			_spawner.SpawnNew();
			
			Started?.Invoke();
		}
		public void StopGame() {
			if (_active == false) {
				return;
			}
			_active = false;
			
			_timer.Ended -= StopGame;
			_timer.Reset();
			_spawner.SomeClicked -= AddScorePoints;
			_spawner.Clear();
			_wallet.Add(_score.Count);
			_wallet.Save();
			_score.Reset();

			Ended?.Invoke();
		}
		private void AddScorePoints() {
			_score.Add(1);
		}

		private void OnDisable() {
			_timer.Ended -= StopGame;
			_timer.Reset();
		}
	}
}
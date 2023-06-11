using System;
using UnityEngine;

namespace Game.Minigames {
	public class Timer: MonoBehaviour {
		private float _timeLeft;
		private bool _active;

		public int TimeLeft => (int)_timeLeft;

		public event Action<int> Changed;
		public event Action Ended;

		private void Update() {
			if (_active) {
				_timeLeft -= Time.deltaTime;
				if (_timeLeft <= 0) {
					StopCountdown();
					return;
				}
				Changed?.Invoke(TimeLeft);
			}
		}
		public void StartCountdown(int time) {
			_active = true;
			_timeLeft = time;
			Changed?.Invoke(TimeLeft);
		}
		public void StopCountdown() {
			_active = false;
			_timeLeft = 0;
			Changed?.Invoke(TimeLeft);
			Ended?.Invoke();
		}
		public void Reset() {
			_active = false;
		}
	}
}
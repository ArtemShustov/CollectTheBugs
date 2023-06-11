using System;
using UnityEngine;

namespace Game {
	public class Wallet: MonoBehaviour {
		[SerializeField] private string _saveKey = "wallet.current";
		private int _count = 0;

		public int Count => _count;

		public event Action<int> Changed;

		private void Awake() {
			Load();
		}

		public void Add(int points) {
			_count += points;
			Changed?.Invoke(_count);
		}
		public void Save() {
			PlayerPrefs.SetInt(_saveKey, _count);
		}
		public void Load() {
			_count = PlayerPrefs.GetInt(_saveKey, 0);
			Changed?.Invoke(_count);
		}
	}
}
using System;
using UnityEngine;

namespace Game.Minigames {
	public class Score: MonoBehaviour {
		private int _count = 0;

		public int Count => _count;

		public event Action<int> Changed;

		public void Add(int points) {
			_count += points;
			Changed?.Invoke(_count);
		}
		public void Reset() {
			_count = 0;
			Changed?.Invoke(0);
		}
	}
}
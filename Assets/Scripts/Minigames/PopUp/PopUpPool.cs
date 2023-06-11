using System;
using UnityEngine;

namespace Game.Minigames.PopUp {
	public class PopUpPool: MonoBehaviour {
		[SerializeField] private RectTransform _root;
		[SerializeField] private Clickable _prefab;
		private Clickable _current;

		public event Action SomeClicked;

		public void SpawnNew() {
			if (_current != null) {
				Destroy(_current.gameObject);
			}
			_current = Instantiate(_prefab, _root);
			_current.GetComponent<RectTransform>().anchoredPosition = new Vector2(
				UnityEngine.Random.Range(-1f, 1f) * _root.rect.size.x * 0.5f,
				UnityEngine.Random.Range(-1f, 1f) * _root.rect.size.y * 0.5f
			);
			_current.Clicked += HandleClick;
		}
		public void Clear() {
			if (_current != null) {
				Destroy(_current.gameObject);
			}
		}

		private void HandleClick() {
			SomeClicked?.Invoke();
			SpawnNew();
		}
	}
}
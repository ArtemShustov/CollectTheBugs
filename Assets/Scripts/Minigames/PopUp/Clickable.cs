using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Minigames.PopUp {
	public class Clickable: MonoBehaviour, IPointerClickHandler {
		public event Action Clicked;

		public void OnPointerClick(PointerEventData eventData) {
			Clicked?.Invoke();
		}
	}
}
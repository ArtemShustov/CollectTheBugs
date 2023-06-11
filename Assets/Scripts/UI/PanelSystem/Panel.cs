﻿using UnityEngine;

namespace Game.UI.PanelSystem {
	public class Panel: MonoBehaviour {
		public void Show() {
			gameObject.SetActive(true);
		}
		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}
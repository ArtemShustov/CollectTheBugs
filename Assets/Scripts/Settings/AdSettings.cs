using UnityEngine;

namespace Game.Settings {
	[CreateAssetMenu(menuName = "Settings/Ad")]
	public class AdSettings: ScriptableObject {
		[field: SerializeField] public string Token { get; private set; } = "demo-rewarded-yandex";
		[field: SerializeField] public int AdBonus { get; private set; } = 10;
	}
}
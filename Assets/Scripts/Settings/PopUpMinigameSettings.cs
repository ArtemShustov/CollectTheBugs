using UnityEngine;

namespace Game.Settings {
	[CreateAssetMenu(menuName = "Settings/PopUp Minigame")]
	public class PopUpMinigameSettings: ScriptableObject {
		[field: SerializeField] public int RoundTime { get; private set; } = 5;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public enum PCT
	{
		NONE,
		YELLOW,
		RED,
		GREEN, 
	}

	[CreateAssetMenu(fileName = "characterSelect", menuName = "Roundbeargames/CharacterSelect/CharacterSelect")]
	public class CharacterSelect : ScriptableObject
	{
		public PCT SelectedCharacterType;
	}
}
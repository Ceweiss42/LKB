using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace roundbeargames_tutorial
{
	public class UIDamageText : MonoBehaviour
	{
		public DamageDetector dd;
		public TextMeshProUGUI damage;
		// Start is called before the first frame update
		void Start()
		{
			damage = GetComponent<TextMeshProUGUI>();
		}

		// Update is called once per frame
		void Update()
		{
			damage.text = "" + dd.GetHP();

		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace roundbeargames_tutorial
{
	public class UIStocksText : MonoBehaviour
	{
		public DamageDetector dd;
		public TextMeshProUGUI stocks;
		// Start is called before the first frame update
		void Start()
		{
			stocks = GetComponent<TextMeshProUGUI>();
		}

		// Update is called once per frame
		void Update()
		{
			stocks.text = "STOCKS: " + dd.GetStocks();

		}
	}

}

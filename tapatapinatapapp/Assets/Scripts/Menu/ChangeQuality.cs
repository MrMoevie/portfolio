using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuality : MonoBehaviour
{
	private bool HighQuality = true;
	public Text text;

	public void ChangeQualityVoid () {
		Debug.Log("Button pressed");
		if(HighQuality) {
			QualitySettings.SetQualityLevel (1, true);
			HighQuality = false;
			Debug.Log("Quality now low");
			text.text = "Quality: Low";
		} else {
			QualitySettings.SetQualityLevel (0, true);
			Debug.Log("Quality now high");
			HighQuality = true;
			text.text = "Quality: High";
		}
	}
}

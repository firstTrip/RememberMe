
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class TMProUGUIDoText
{
	// 확장 메서드 사용 버전 필요없으면 this만 빼고 사용
	public static void DoText(this TextMeshProUGUI a_text, float a_duration)
	{
		a_text.maxVisibleCharacters = 0;
		DOTween.To(x => a_text.maxVisibleCharacters = (int)x, 0f, a_text.text.Length, a_duration);
	}
}
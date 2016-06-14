using UnityEngine;
using System.Collections.Generic;

public class ScoreSprite : MonoBehaviour {

	[SerializeField]
	private SpriteRenderer _MajorDigit;

	[SerializeField]
	private SpriteRenderer _MinorDigit;

	[SerializeField]
	private List<Sprite> _Values = new List<Sprite>();

	public void SetScore(int score)
	{
		var scoreMod = score % 10;
		var scoreRemainder = score / 10;
		if (scoreRemainder > 0) {
			var spriteMajor = _Values [scoreRemainder];
			_MajorDigit.sprite = spriteMajor;
			_MajorDigit.enabled = true;
		} else {
			_MajorDigit.enabled = false;
		}
		var spriteMinor = _Values [scoreMod];
		_MinorDigit.sprite = spriteMinor;
	}
}

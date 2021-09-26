using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakableController : MonoBehaviour
{
	[SerializeField] private List<Color> listColor;
	[SerializeField] private SpriteRenderer mySpriteRenderer;
	
	private void Start()
	{
		var index = Random.Range(0, listColor.Count);
		var color = listColor[index];
		mySpriteRenderer.color = color;
	}
}
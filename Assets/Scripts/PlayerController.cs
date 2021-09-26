using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 1;
	[SerializeField] private float limitX = 7.4f;

	private void Update()
	{
		var input = Input.GetAxis("Horizontal");

		var position = transform.position;
		position.x += input * speed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, -limitX, limitX);
		transform.position = position;
	}
}
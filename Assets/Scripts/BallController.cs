using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;

	[SerializeField] private float speed = 1f;
	[SerializeField] private LevelManager levelManager;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		var random = Random.value > .5f ? .5f : -.5f;
		var force = new Vector2(random, -1);
		_rigidbody2D.AddForce(force.normalized * speed);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Breakable"))
		{
			other.gameObject.SetActive(false);
			if (levelManager.CheckWin())
			{
				Debug.Log("Win!");
				Time.timeScale = 0;
			}
		}

		if (other.transform.CompareTag("GameOver"))
		{
			Debug.Log("Game Over");
			Time.timeScale = 0;
		}
			
		
	}
}
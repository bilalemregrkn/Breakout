using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private GameObject breakablePrefab;
	[SerializeField] private Vector2Int size;
	[SerializeField] private Vector2 offet;

	[SerializeField] private List<GameObject> breakables;

	public bool CheckWin()
	{
		foreach (var item in breakables)
			if (item.activeSelf)
				return false;

		return true;
	}
	
	[ContextMenu(nameof(Create))]
	public void Create()
	{
		var parent = new GameObject { transform = { name = "Parent" } };

		var list = new List<GameObject>();
		for (int i = 0; i < size.x; i++)
		{
			for (int j = 0; j < size.y; j++)
			{
				var x = i * offet.x;
				var y = j * offet.y;
				var position = new Vector3(x, y, 0);
				var breakable =Instantiate(breakablePrefab, position, quaternion.identity);
				list.Add(breakable);
			}
		}

		Vector3 origin = Vector3.zero;
		foreach (var item in list) 
			origin += item.transform.position;
		
		origin /= list.Count;

		parent.transform.position = origin;

		foreach (var item in list)
			item.transform.SetParent(parent.transform);
		
		parent.transform.position = Vector3.zero;

		breakables = new List<GameObject>(list);
	}
}
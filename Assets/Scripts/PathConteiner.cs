using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathConteiner : MonoBehaviour
{
	private Dictionary<int ,Path> _pathList;
	private List<int> _playerIDs;

	private Checkpoint[] _checkpoints;

	public int PathList
	{
		get { return _pathList.Count; }
	}

	private void Start()
	{

		

	}

	public void FindCheckpoints()
	{
		_checkpoints = Object.FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
	}


	
}

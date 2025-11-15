using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathConteiner : MonoBehaviour
{
	private Dictionary<int, Path> _pathList;		

	public int PathList
	{
		get { return _pathList.Count; }
	}

	private void Start()
	{

		FindAndCreatePaths();

	}

	public void FindAndCreatePaths()
	{
		Checkpoint[] _checkpoints = Object.FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);

		foreach (Checkpoint checkpoint in _checkpoints) 
		{
			_pathList.TryAdd(checkpoint.GetPlayerID(), new Path());
			_pathList[checkpoint.GetPlayerID()].AddCheckpoint(checkpoint);						
		}

		Debug.Log(_pathList.Count);
	}


	
}

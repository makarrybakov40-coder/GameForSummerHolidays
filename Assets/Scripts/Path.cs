using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Path
{

	private List<Checkpoint> _listOfCheckpoints;	
	private int _currentPosition;	

	public void AddCheckpoint(Checkpoint checkpoint)
	{
		_listOfCheckpoints.Add(checkpoint);
	}

}
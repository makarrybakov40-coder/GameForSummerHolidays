using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour 
{

	private List<Checkpoint> _listOfCheckpoints;
	private int _playerID;
	private int _currentPosition;

	
	public int PlayerID
	{
		get { return _playerID; }
	}

}
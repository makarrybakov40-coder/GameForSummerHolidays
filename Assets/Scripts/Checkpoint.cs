using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField] private int _playerID;

	[SerializeField] private int _pathIndexNumber;

	public int GetPlayerID()
	{
		return _playerID;
	}
}

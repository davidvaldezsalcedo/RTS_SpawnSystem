using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GameObject", fileName = "GO_")]
public class RefGameObject : ScriptableObject 
{
	[SerializeField]
	private GameObject _Value;	
	public GameObject Value
	{
		get
		{
			return _Value;
		}
		set
		{
			_Value = value;
		}
	}
}

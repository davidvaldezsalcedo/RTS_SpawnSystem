using UnityEngine;

public class AssignGO : MonoBehaviour 
{
	[SerializeField]
	private RefGameObject _Target;

	private void Awake()
	{
		_Target.Value = gameObject;
	}
}

using UnityEngine;
using UnityEngine.AI;

public class GoToTarget : MonoBehaviour 
{
	[SerializeField]
	private RefGameObject _CurrentTarget;
	private NavMeshAgent _Agent;

	private void Awake()
	{
		_Agent = GetComponent<NavMeshAgent>();

		_Agent.SetDestination(_CurrentTarget.Value.transform.position);
	}

}

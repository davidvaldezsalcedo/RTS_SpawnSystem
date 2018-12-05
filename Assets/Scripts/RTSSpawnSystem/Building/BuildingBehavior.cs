using System.Collections.Generic;
using UnityEngine;

namespace RTSSpawner
{	
	public class BuildingBehavior : MonoBehaviour, ICollideable
	{
		[SerializeField]
		private BuildingData _BuildingType;
		[SerializeField]
		private bool _SpawnsUnits;
		[SerializeField]
		private RefBool _MouseHoveringUI;
		[SerializeField]
		private bool _CanSpawn = false;

		private void OnMouseDown()
		{
			if(_MouseHoveringUI.Value == false && _CanSpawn == true)
			{
				EventHandlers.Trigger_BuildingSelectedEvent(_BuildingType, transform.position, _SpawnsUnits);
			}	
			
			_CanSpawn = true;
		}
	}
}
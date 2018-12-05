using System;
using UnityEngine;

namespace RTSSpawner
{	
	public class EventHandlers : MonoBehaviour 
	{
		public static event Action<BuildingData, Vector3, bool> BuildingSelectedEvent;
		public static event Action<GameObject, Vector3> SpawnUnitEvent;
		public static event Action<GameObject> SpawnBuildingEvent;

		public static void Trigger_BuildingSelectedEvent(BuildingData BuildingType, Vector3 posToSpawn, bool SpawnsUnits)
		{
			BuildingSelectedEvent.Invoke(BuildingType, posToSpawn, SpawnsUnits);
		}

		public static void Trigger_SpawnUnitEvent(GameObject ObjectToSpawn, Vector3 posToSpawn)
		{
			SpawnUnitEvent.Invoke(ObjectToSpawn, posToSpawn);
		}

		public static void Trigger_SpawnBuildingEvent(GameObject ObjectToSpawn)
		{
			SpawnBuildingEvent.Invoke(ObjectToSpawn);
		}
	}
}
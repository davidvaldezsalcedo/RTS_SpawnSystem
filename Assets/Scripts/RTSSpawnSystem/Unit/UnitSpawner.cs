using UnityEngine;

namespace RTSSpawner
{
	public class UnitSpawner : MonoBehaviour 
	{
		private void OnEnable()
		{
			EventHandlers.SpawnUnitEvent += SpawnUnit;	
		}

		private void OnDisable()
		{
			EventHandlers.SpawnUnitEvent -= SpawnUnit;	
		}

		private void SpawnUnit(GameObject unitToSpawn, Vector3 posToSpawn)
		{
			Instantiate(unitToSpawn, posToSpawn, Quaternion.identity);
		}
	}
}

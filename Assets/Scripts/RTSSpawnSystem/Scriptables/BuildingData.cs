using UnityEngine;
using UnityEngine.UI;

namespace RTSSpawner
{
	[CreateAssetMenu(menuName = "Buildings/BuildingType", fileName = "Building_")]
	public class BuildingData : ScriptableObject 
	{
		public GameObject[] ObjectsInBuilding;
		public Sprite[] ImagesForObjects;
		public string[] TextForButtons;
	}
}

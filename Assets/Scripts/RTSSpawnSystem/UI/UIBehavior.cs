using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine.UI;
using UnityEngine;

namespace RTSSpawner
{	
	public class UIBehavior : MonoBehaviour 
	{
		[SerializeField]
		private List<Button> _Buttons = new List<Button>();
		private bool _SpawnsUnits;
		private Vector3 _PosToSpawn;

		private void Awake()
		{
			EventHandlers.BuildingSelectedEvent += ShowMenu;

			foreach (var button in GetComponentsInChildren<Button>(true))
			{
				_Buttons.Add(button);
			}
		}

		private void OnDisable()
		{
			EventHandlers.BuildingSelectedEvent -= ShowMenu;
		}

		private void ShowMenu(BuildingData buildingType, Vector3 posToSpawn, bool spawnsUnits)
		{
			_SpawnsUnits = spawnsUnits;
			_PosToSpawn = posToSpawn;

			for (int i = 0; i < _Buttons.Count; ++i)
			{
				_Buttons[i].gameObject.SetActive(false);
				_Buttons[i].onClick.RemoveAllListeners();
			}

			for (int i = 0; i < _Buttons.Count; ++i)
			{
				if(i <= buildingType.ObjectsInBuilding.Length - 1)
                {
                    SetUpButtons(buildingType, i);
					GameObject objectToSpawn = buildingType.ObjectsInBuilding[i];
					_Buttons[i].onClick.AddListener(() => Spawn(objectToSpawn));                
				}
            }
		}

        private void SetUpButtons(BuildingData buildingType, int index)
        {
            _Buttons[index].image.sprite = buildingType.ImagesForObjects[index];
            _Buttons[index].GetComponentInChildren<Text>().text = buildingType.TextForButtons[index];
            _Buttons[index].gameObject.SetActive(true);
        }

        public void Spawn(GameObject objectType)
		{
			if(_SpawnsUnits == true)
			{
				EventHandlers.Trigger_SpawnUnitEvent(objectType, _PosToSpawn);
			}
			else
			{
				EventHandlers.Trigger_SpawnBuildingEvent(objectType);
			}
		}
	}
}
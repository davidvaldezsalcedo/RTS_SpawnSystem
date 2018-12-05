using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSSpawner
{	
	public class BuildingSpawner : MonoBehaviour 
	{
		[SerializeField]
		private RefCamera _Camera;
		[SerializeField]
		private LayerMask _LayerToCheck;
		[SerializeField]
		private RefBool _MouseHoveringUI;

		private IEnumerator _CurrentState;

		private void OnEnable()
		{
			EventHandlers.SpawnBuildingEvent += SpawnBuilding;
		}

		private void OnDisable()
		{
			EventHandlers.SpawnBuildingEvent -= SpawnBuilding;
			StopAllCoroutines();
		}

		private void SetState(IEnumerator newState)
		{
			if(_CurrentState != null)
			{
				StopCoroutine(_CurrentState);
			}
			_CurrentState = newState;
			StartCoroutine(_CurrentState);
		}

		public void SpawnBuilding(GameObject ObjectType)
		{
			Ray ray = _Camera.Value.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 200, _LayerToCheck))
			{
				GameObject clone = Instantiate(ObjectType, hit.point, Quaternion.identity);
				MeshRenderer buildingRenderer = clone.GetComponentInChildren<MeshRenderer>();
				SetState(MoveBuilding(clone, buildingRenderer, buildingRenderer.material));
			}
		}

		private IEnumerator MoveBuilding(GameObject building, MeshRenderer buildingRenderer, Material buildingMat)
		{
			while (Input.GetMouseButtonDown(0) == false)
			{
				Ray ray = _Camera.Value.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, 200, _LayerToCheck))
				{
					Vector3 point = hit.point;
					building.transform.position = Vector3.Lerp(building.transform.position, hit.point, Time.deltaTime * 20f);
					float mouseScrollAmount = Input.GetAxis("Mouse ScrollWheel");
					if(mouseScrollAmount != 0)
					{
						Quaternion buildingRot = building.transform.rotation;
		
						buildingRot.y += mouseScrollAmount;
						building.transform.rotation = buildingRot;
					}
				}
				yield return null;
			}
			
			if(_MouseHoveringUI.Value == false && buildingRenderer.material == buildingMat)
			{
				Destroy(building.GetComponent<SpawnMaterialChanger>());
			}
			else
			{
				Destroy(building);
			}
		}
	}
}
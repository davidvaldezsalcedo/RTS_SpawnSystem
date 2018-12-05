using UnityEngine;

namespace RTSSpawner
{	
	public class SpawnMaterialChanger : MonoBehaviour 
	{
		[SerializeField]
		private Material _InvalidSpawnMat;
		[SerializeField]
		private LayerMask _LayerToCheck;
		[SerializeField]
		private MeshRenderer _Renderer;

		[Header("Collider Modifiers")]
		[SerializeField]
		private Vector3 _CollisionScale;
		[SerializeField]
		private float _XColModifier = 0;
		[SerializeField]
		private float _YColModifier = 5;
		[SerializeField]
		private float _ZColModifier = 0;
		
		private Material _OriginalMat;

		private void Awake()
		{
			_OriginalMat = GetComponentInChildren<MeshRenderer>().material;
			GetComponent<Collider>().isTrigger = true;
		}

		private void OnDestroy()
		{
			GetComponent<Collider>().isTrigger = false;
		}
		
		private void Update()
		{
			CheckCollisions();
		}

		private void CheckCollisions()
		{
			Vector3 colliderOrigin = new Vector3
			(
				transform.position.x + _XColModifier, 
				transform.position.y + _YColModifier, 
				transform.position.z + _ZColModifier
			);

			Collider[] colsDetected = Physics.OverlapBox(colliderOrigin, _CollisionScale, transform.rotation, _LayerToCheck, QueryTriggerInteraction.Ignore);
			if(colsDetected.Length > 0)
			{
				foreach (var col in colsDetected)
				{
					if(col.GetComponent<ICollideable>() != null)
					{
						_Renderer.material = _InvalidSpawnMat;
					}
				}
				return;
			}

			_Renderer.material = _OriginalMat;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			Vector3 colliderOrigin = new Vector3
			(
				transform.position.x + _XColModifier, 
				transform.position.y + _YColModifier, 
				transform.position.z + _ZColModifier
			);

			Gizmos.DrawWireCube(colliderOrigin, _CollisionScale);
		}
	}
}
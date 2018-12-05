using UnityEngine;
using UnityEngine.EventSystems;

namespace RTSSpawner
{	
	public class UIHoverListener : MonoBehaviour 
	{
		[SerializeField]
		private RefBool _MouseHoveringUI;

		void Update()
		{
			// Check if hovering on any UI Elements
			_MouseHoveringUI.Value = EventSystem.current.IsPointerOverGameObject();
		}
	}
}
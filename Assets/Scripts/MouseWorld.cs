using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

	private static MouseWorld instance;
	[SerializeField] private LayerMask mousePlaneLayerMask;


	private void Awake()
	{
		instance = this;
	}

	public static Vector3 GetPosition()
	{
		//fire ray from the camera to where the mouse points
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//register where the ray hit
		Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
		//returns the point where the ray has hit
		return raycastHit.point;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;

	private void Update()
	{


		if (Input.GetMouseButtonDown(0))
		{
			selectedUnit.Move(MouseWorld.GetPosition());
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

	public static UnitActionSystem Instance { get; private set; }

	public event EventHandler OnSelectedUnitChanged;


    [SerializeField] private Unit selectedUnit;
	[SerializeField] private LayerMask selectedUnitLayerMask;

	private void Awake()
	{
		//Checking to see if there is an istance of the UnitActionSystem already, and destroys it so we can proceed
		if (Instance != null) 
		{
			Debug.LogError("There is more than one UnitActionSystem!" + transform + " - " + Instance);
			Destroy(Instance);
			return;
		}

		Instance = this;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (TryHandleUnitSelection()) return;

			GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());

			if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
			{
				selectedUnit.GetMoveAction().Move(mouseGridPosition);
			}
		}
	}


	private bool TryHandleUnitSelection()
	{

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, selectedUnitLayerMask))
		{
			//get component of type Unit if there is such, just helps to not use a null check
			if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
			{
				SetSelectedUnit(unit);
				return true;
			}
		}

		return false;
	}

	private void SetSelectedUnit(Unit unit)
	{
		selectedUnit = unit;
		//check if the unit is changed, if it is null, the following won't be called(invoked)
		OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
	}

	public Unit GetSelectedUnit()
	{
		return selectedUnit;
	}
}

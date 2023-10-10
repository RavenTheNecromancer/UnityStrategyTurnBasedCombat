using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
	//reference to the unit
    [SerializeField] private Unit unit;

	//reference to the visual
    private MeshRenderer meshRenderer;

	private void Awake()
	{
		//assigning the visual to the reference
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void Start()
	{
		UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChange;
		UpdateVisual();
	}

	private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty)
	{
		UpdateVisual();
	}

	private void UpdateVisual()
	{
		if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
		{
			meshRenderer.enabled = true;
		}
		else
		{
			meshRenderer.enabled = false;
		}
	}
}

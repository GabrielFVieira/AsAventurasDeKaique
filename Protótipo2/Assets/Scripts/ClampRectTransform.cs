﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampRectTransform : MonoBehaviour {

	public float padding = 15.0f;
	public float elementSize = 250.0f;
	public float viewSize = 600.0f;

	private RectTransform rt;
	private int amountElements;
	private float contentSize;

	private void Start()
	{
		rt = GetComponent<RectTransform> ();
	}

	private void Update()
	{
		//Clamp our rect transform
		amountElements = rt.childCount;
		contentSize = ((amountElements * (elementSize + padding)) - viewSize) * rt.localScale.x;

		if (rt.localScale.x > padding)
			rt.localPosition = new Vector3 (padding, rt.localPosition.y, rt.localPosition.z);

		if(rt.localPosition.x < - contentSize)
			rt.localPosition = new Vector3 (-contentSize, rt.localPosition.y, rt.localPosition.z);
	}
}

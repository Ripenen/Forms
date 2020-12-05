﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screen : MonoBehaviour
{

	public Image image;

	private static Color faderColor;
	private static float maxTime, curTime;
	private static bool isColor, isClear, fade;

	public static void Fader(float time, Color color)
	{
		if (curTime != 0) return;
		isClear = false;
		isColor = false;
		fade = !fade;
		faderColor = color;
		faderColor.a = 1;
		maxTime = time;
	}

	public static void Fader(float time)
	{
		if (curTime != 0) return;
		isClear = false;
		isColor = false;
		fade = !fade;
		faderColor.a = 1;
		maxTime = time;
	}

	void Awake()
	{
		fade = true;
		faderColor = Color.black; // цвет по умолчанию
		image.color = new Color(0, 0, 0, 0); // цвет на старте
	}

	void SetClear()
	{
		if (isClear) return;
		faderColor.a = 1 - GetValue();
		image.color = faderColor;
		if (image.color.a <= 0)
		{
			image.color = faderColor;
			isClear = true;
			curTime = 0;
		}
	}

	void SetColor()
	{
		if (isColor) return;
		faderColor.a = GetValue();
		image.color = faderColor;
		if (image.color.a >= 1)
		{
			image.color = faderColor;
			isColor = true;
			curTime = 0;
		}
	}

	float GetValue()
	{
		float t = 0;
		curTime += Time.deltaTime;
		t = curTime / maxTime;
		return t;
	}

	void Update()
	{
		
	}

	public static bool screenColor // true, когда экран полностью закрашен
	{
		get { return isColor; }
	}

	public static bool screenClear // true, когда экран чистый
	{
		get { return isClear; }
	}
}

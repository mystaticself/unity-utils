using UnityEngine;
using System.Collections;

[System.Serializable]
public class Range
{
	public float min = 0f;
	public float max = 0f;
	
	public Range(){}
	
	public Range(float min, float max)
	{
		this.min = min;
		this.max = max;
	}
	
	public bool IsInRange(float num)
	{
		return num >= min && num <= max;
	}
	
	override public string ToString()
	{
		return "Range: min="+min+", max="+max;	
	}
}

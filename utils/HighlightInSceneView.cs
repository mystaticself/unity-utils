using UnityEngine;
using System.Collections;

public class HighlightInSceneView : MonoBehaviour 
{
	public Color color = Color.white;
	
	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireSphere(transform.position, 1f);	
	}
}

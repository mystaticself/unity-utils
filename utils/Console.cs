#define DEBUG_LEVEL_LOG
#define DEBUG_LEVEL_WARN
#define DEBUG_LEVEL_ERROR

using UnityEngine;
using System.Collections;

public class Console
{
	public static bool DEBUG = true;
	
	[System.Diagnostics.Conditional("DEBUG_LEVEL_LOG")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_WARN")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_ERROR")]
	public static void Log(string format, params object[] paramList)
	{
		if(!DEBUG) return;
		Debug.Log(string.Format(format, paramList));	
		#if UNITY_WEBPLAYER
		string log = "console.log(\"" + string.Format(format, paramList) + "\")";
		Application.ExternalEval(log);
		#endif
	}
	
	[System.Diagnostics.Conditional("DEBUG_LEVEL_WARN")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_ERROR")]
	public static void Warn(string format, params object[] paramList)
	{
		if(!DEBUG) return;
		Debug.LogWarning(string.Format(format, paramList));	
		#if UNITY_WEBPLAYER
		Application.ExternalEval("console.log('[WARNING]: "+string.Format(format, paramList)+"')");
		#endif
	}
	
	[System.Diagnostics.Conditional("DEBUG_LEVEL_ERROR")]
	public static void Error(string format, params object[] paramList)
	{
		Debug.LogError(string.Format(format, paramList));	
		#if UNITY_WEBPLAYER
		Application.ExternalEval("console.log('[ERROR]: "+string.Format(format, paramList)+"')");
		#endif
	}
	
	[System.Diagnostics.Conditional("UNITY_EDITOR")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_LOG")]
	public static void Assert(bool condition)
	{
		Assert(condition, string.Empty, true);
	}
	
	[System.Diagnostics.Conditional("UNITY_EDITOR")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_LOG")]
	public static void Assert(bool condition, string assertString)
	{
		Assert(condition, assertString, false);
	}
	
	[System.Diagnostics.Conditional("UNITY_EDITOR")]
	[System.Diagnostics.Conditional("DEBUG_LEVEL_LOG")]
	public static void Assert(bool condition, string assertString, bool pauseOnFail)
	{
		if(!condition)
		{
			Debug.LogError("Assert Failed! " + assertString);
			if(pauseOnFail) Debug.Break();
		}
	}
}

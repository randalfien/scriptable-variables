using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoolVariable))]
public class BoolVariableInspector : Editor 
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		DrawDefaultInspector();
		if ( Application.isPlaying )
		{
			var variable = (BoolVariable) target;
			variable.RuntimeValue = EditorGUILayout.Toggle("Value:", variable.RuntimeValue);
		}
	}
}

[CustomEditor(typeof(IntVariable))]
public class IntVariableInspector : Editor 
{
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		DrawDefaultInspector();
		if ( Application.isPlaying )
		{
			var variable = (IntVariable) target;
			variable.RuntimeValue = EditorGUILayout.IntField("Value:", variable.RuntimeValue);
		}
	}
}

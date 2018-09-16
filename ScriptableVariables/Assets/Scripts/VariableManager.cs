using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "varManager", menuName = "Variables/Variable Manager")]
public class VariableManager : ScriptableObject
{
	public List<BaseVariable> Variables = new List<BaseVariable>();

	public void RefreshList()
	{
		Variables = new List<BaseVariable>(GetAllVariables());
	}

	// This method works only in Editor
	private static BaseVariable[] GetAllVariables()
	{
		string[] guids = AssetDatabase.FindAssets("t:BaseVariable");
		BaseVariable[] vars = new BaseVariable[guids.Length];
		for (int i = 0; i < guids.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(guids[i]);
			vars[i] = AssetDatabase.LoadAssetAtPath<BaseVariable>(path);
			if (string.IsNullOrEmpty(vars[i].Guid))
			{
				vars[i].Guid = guids[i];
			}
		}
		return vars;
	}
}
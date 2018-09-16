using System;
using UnityEngine;

[Serializable]
public abstract class VariableData
{
}

public abstract class BaseVariable : ScriptableObject
{
	[HideInInspector]
	public string Guid;
	
	//Persistence
	public abstract VariableData GetData();
	public abstract void LoadFromData(VariableData data);
}

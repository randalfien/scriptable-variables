using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VariableRevision {
	
	[SerializeField] Dictionary<string, VariableData> Data = new Dictionary<string, VariableData>();
	
	public void LoadFromList(List<BaseVariable> list)
	{
		Data.Clear();
		foreach (var v in list)
		{
			Data.Add(v.Guid, v.GetData());
		}
	}

	public void RestoreVariable(List<BaseVariable> list)
	{
		foreach (var v in list)
		{
			VariableData d;
			if (Data.TryGetValue(v.Guid, out d))
			{
				v.LoadFromData(d);
			}
		}
	}
}

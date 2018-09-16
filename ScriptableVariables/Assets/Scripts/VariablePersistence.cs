using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class VariablePersistence : MonoBehaviour
{
	public VariableManager VariableManager;

	private const string SavePath = "Temp/save.savefile";

	private void Start()
	{
		if (VariableManager == null)
		{
			Debug.LogError("No variable manager assigned!");
			return;
		}
#if UNITY_EDITOR
		VariableManager.RefreshList();
#endif
	}

	public void Save()
	{
		var revision = new VariableRevision();
		revision.LoadFromList(VariableManager.Variables);

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(SavePath);
		bf.Serialize(file, revision);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists(SavePath))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(SavePath, FileMode.Open);
			var revision = (VariableRevision) bf.Deserialize(file);
			revision.RestoreVariable(VariableManager.Variables);
			file.Close();
		}
	}
}
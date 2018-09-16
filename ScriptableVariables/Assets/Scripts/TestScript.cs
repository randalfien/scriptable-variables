using UnityEngine;

public class TestScript : MonoBehaviour
{
	private VariablePersistence _persistence;

	void OnGUI()
	{
		GUI.Box(new Rect(30, 30, 140, 140), "Persistence");

		if (GUI.Button(new Rect(40, 60, 120, 40), "Save"))
		{
			_persistence.Save();
		}

		if (GUI.Button(new Rect(40, 120, 120, 40), "Load"))
		{
			_persistence.Load();
		}
	}

	void Start()
	{
		_persistence = FindObjectOfType<VariablePersistence>();
	}
}
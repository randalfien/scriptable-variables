using System;

public abstract class Variable<T> : BaseVariable {
	
	[Serializable]
	private class VariableData<TV> : VariableData
	{
		public TV Value;
	}
	
	public T DefaultValue;

	public T RuntimeValue { get; set; }
	
	protected void OnEnable()
	{
		RuntimeValue = DefaultValue;
	}
	
	public override VariableData GetData()
	{
		return new VariableData<T>
		{
			Value = RuntimeValue
		};
	}

	public override void LoadFromData(VariableData data)
	{
		RuntimeValue = ((VariableData<T>) data).Value;
	}
}

using UnityEngine;

public abstract class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
{
	public static T Instance;

	protected void Awake()
	{
		if(Instance == null)
		{
			Instance = GetComponent<T>();
			SingletonAwake();
		}
		else
		{
			Destroy(this);
		}
	}

	protected abstract void SingletonAwake();
}

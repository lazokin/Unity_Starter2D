using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class representing a MonoBehaviour Singleton which does not persist across scenes.
/// </summary>
public abstract class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T>
{
	public static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				T[] objects = FindObjectsOfType<T> ();
				if (objects.Length == 0)
				{
					Debug.LogError ("No active [" + typeof(T).Name + "] in scene.");
					return null;
				}
				if (objects.Length > 1)
				{
					Debug.LogError ("More than one [" + typeof(T).Name + "] in scene.");
					return null;
				}
				instance = objects [0];
				instance.Init ();
			}
			return instance;
		}
	}

	/// <summary>
	/// Used to initialize the class.
	/// </summary>
	protected abstract void Init ();
}
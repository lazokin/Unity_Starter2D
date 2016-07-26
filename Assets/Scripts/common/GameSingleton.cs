using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class representing a MonoBehaviour Singleton which persists across scenes.
/// </summary>
public abstract class GameSingleton<T> : MonoBehaviour where T : GameSingleton<T>
{
	public static T Instance { get; private set; }

	void Awake ()
	{
		if (Instance == null) {
			Debug.Log ("[" + gameObject.name + "|" + this.GetType() + "] Setting singleton on this game object.");
			Instance = this as T;
			DontDestroyOnLoad (this);
			Init ();
		} else {
			Debug.Log ("[" + gameObject.name + "|" + this.GetType() + "] Singleton already instatiated. Destroying this game object.");
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Used to initialize the class.
	/// </summary>
	protected abstract void Init ();
}

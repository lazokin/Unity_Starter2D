using UnityEngine;
using System.Collections;

public class PositionCamera : MonoBehaviour
{
	void Start ()
    {
		GetComponent<Camera>().orthographicSize = SceneManager.Instance.SceneHeight / 2;
    }
}

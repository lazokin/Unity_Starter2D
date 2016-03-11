using UnityEngine;
using System.Collections;

public class PositionCamera : MonoBehaviour
{
    public SceneDimensions sceneDimensions;

	void Start ()
    {
        GetComponent<Camera>().orthographicSize = sceneDimensions.SceneHeight / 2;
    }

	void Update () 
	{

	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// A class containing scene dimensions
/// </summary>
public class SceneManager : SceneSingleton<SceneManager>
{
	// safe lengths
	private float safeLengthLong = 1920;
	private float safeLengthShort = 1280;
	private float safeAspectRatio;

	// screen dimensions
	private float screenWidth;
	private float screenHeight;
	private float screenAspectRatio;

	// orientation flags
	private bool isLandscape;
	private bool isPortrait;

	// fullscreen (4:3) dimensions (based off safe dimensions)
	private float fullscreenWidth;
	private float fullscreenHeight;
	private float fullscreenAspectRatio;

	// widescreen (16:9) dimensions (based off safe dimensions)
	private float widescreenWidth;
	private float widescreenHeight;
	private float widescreenAspectRatio;

	// safe dimension properies
	public float SafeWidth { get; private set; }
	public float SafeHeight { get; private set; }
	public float SafeLeft { get; private set; }
	public float SafeRight { get; private set; }
	public float SafeTop { get; private set; }
	public float SafeBottom { get; private set; }

	// scene dimension properies
	public float SceneWidth { get; private set; }
	public float SceneHeight { get; private set; }
	public float SceneLeft { get; private set; }
	public float SceneRight { get; private set; }
	public float SceneTop { get; private set; }
	public float SceneBottom { get; private set; }

	protected sealed override void Init ()
	{
		// do nothing
	}

	void Awake ()
	{
		// calculate screen dimensions
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		screenAspectRatio = AspectRatio (screenWidth, screenHeight);

		// calculate orientation
		isLandscape = screenWidth > screenHeight ? true : false;
		isPortrait = screenHeight > screenWidth ? true : false;

		// calculate safe dimensions
		if (isLandscape) {
			SafeWidth = safeLengthLong;
			SafeHeight = safeLengthShort;
		}
		if (isPortrait) {
			SafeWidth = safeLengthShort;
			SafeHeight = safeLengthLong;
		}
		SafeLeft = -SafeWidth / 2f;
		SafeRight = SafeWidth / 2f;
		SafeTop = SafeHeight / 2f;
		SafeBottom = -SafeHeight / 2f;

		// calculate design ratios
		if (isLandscape) {
			safeAspectRatio = AspectRatio (safeLengthLong, safeLengthShort);
		}
		if (isPortrait) {
			safeAspectRatio = AspectRatio (safeLengthShort, safeLengthLong);
		}

		// calculate scene dimensions
		if (screenAspectRatio < safeAspectRatio) {
			SceneWidth = SafeWidth;
			SceneHeight = Height (SceneWidth, screenAspectRatio);
		} else {
			SceneHeight = SafeHeight;
			SceneWidth = Width (SceneHeight, screenAspectRatio);
		}

		SceneLeft = -SceneWidth / 2f;
		SceneRight = SceneWidth / 2f;
		SceneTop = SceneHeight / 2f;
		SceneBottom = -SceneHeight / 2f;

	}

	// calculate width given height, where aspect ratio is width/height.
	float Width (float height, float aspectRatio)
	{
		return height * aspectRatio;
	}

	// calculate height given width, where aspect ratio is width/height.
	float Height (float width, float aspectRatio)
	{
		return width / aspectRatio;
	}

	// calculate aspect ratio, where aspect ratio is width/height.
	float AspectRatio (float width, float height)
	{
		return width / height;
	}

}

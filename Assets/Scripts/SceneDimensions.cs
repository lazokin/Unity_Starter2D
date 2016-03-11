using UnityEngine;
using System.Collections;

public class SceneDimensions : MonoBehaviour
{
    // safe lengths
    private float safeLengthLong = 1920;
    private float safeLengthShort = 1280;

    // screen dimensions
    private float screenWidth;
    private float screenHeight;
    private float screenAspectRatio;

    // orientation flags
    private bool isLandscape;
    private bool isPortrait;

    // safe dimensions
    private float safeWidth;
    private float safeHeight;
    private float safeLeft;
    private float safeRight;
    private float safeTop;
    private float safeBottom;

    // fullscreen (4:3) dimensions (based off safe dimensions)
    private float fullscreenWidth;
    private float fullscreenHeight;
    private float fullscreenAspectRatio;

    // widescreen (16:9) dimensions (based off safe dimensions)
    private float widescreenWidth;
    private float widescreenHeight;
    private float widescreenAspectRatio;

    // scene dimensions
    private float sceneWidth;
    private float sceneHeight;
    private float sceneLeft;
    private float sceneRight;
    private float sceneTop;
    private float sceneBottom;

    // safe dimension properies
    public float SafeWidth { get { return safeWidth; } }
    public float SafeHeight { get { return safeHeight; } }
    public float SafeLeft { get { return safeLeft; } }
    public float SafeRight { get { return safeRight; } }
    public float SafeTop { get { return safeTop; } }
    public float SafeBottom { get { return safeBottom; } }

    // scene dimension properies
    public float SceneWidth { get { return sceneWidth;  } }
    public float SceneHeight { get { return sceneHeight; } }
    public float SceneLeft { get { return sceneLeft; } }
    public float SceneRight { get { return sceneRight; } }
    public float SceneTop { get { return sceneTop; } }
    public float SceneBottom { get { return sceneBottom; } }

    void Awake ()
    {
        // calculate screen dimensions
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        screenAspectRatio = AspectRatio(screenWidth, screenHeight);

        // calculate orientation
        isLandscape = screenWidth > screenHeight ? true : false;
        isPortrait = screenHeight > screenWidth ? true : false;

        // calculate safe dimensions
        if (isLandscape)
        {
            safeWidth = safeLengthLong;
            safeHeight = safeLengthShort;
        }
        if (isPortrait)
        {
            safeWidth = safeLengthShort;
            safeHeight = safeLengthLong;
        }
        safeLeft = -safeWidth / 2;
        safeRight = safeWidth / 2;
        safeTop = safeHeight / 2;
        safeBottom = -safeHeight / 2;

        // calculate aspect ratios
        if (isLandscape)
        {
            fullscreenAspectRatio = AspectRatio(4.0f, 3.0f);
            widescreenAspectRatio = AspectRatio(16.0f, 9.0f);
        }
        if (isPortrait)
        {
            fullscreenAspectRatio = AspectRatio(3.0f, 4.0f);
            widescreenAspectRatio = AspectRatio(9.0f, 16.0f);
        }

        // calculate fullscreen dimensions
        if (isLandscape)
        {
            fullscreenWidth = safeWidth;
            fullscreenHeight = Height(fullscreenWidth, fullscreenAspectRatio);
        }
        if (isPortrait)
        {
            fullscreenHeight = safeHeight;
            fullscreenWidth = Width(fullscreenHeight, fullscreenAspectRatio);
        }

        // calculate widescreen dimensions
        if (isLandscape)
        {
            widescreenHeight = safeHeight;
            widescreenWidth = Width(widescreenHeight, widescreenAspectRatio);
        }
        if (isPortrait)
        {
            widescreenWidth = safeWidth;
            widescreenHeight = Height(widescreenWidth, widescreenAspectRatio);
        }

        // calculate scene dimensions
        sceneHeight = Interpolate(
            screenAspectRatio,
            fullscreenAspectRatio,
            fullscreenHeight,
            widescreenAspectRatio,
            widescreenHeight
        );
        sceneWidth = Width(sceneHeight, screenAspectRatio);
        sceneLeft = -sceneWidth / 2;
        sceneRight = sceneWidth / 2;
        sceneTop = sceneHeight / 2;
        sceneBottom = -sceneHeight / 2;

    }

    // two-point form linear interpolation. given x, solve for y.
    float Interpolate(float x, float x1, float y1, float x2, float y2)
    {
        return ((y2 - y1) / (x2 - x1)) * (x - x1) + y1;
    }

    // calculate width given height, where aspect ratio is width/height.
    float Width(float height, float aspectRatio)
    {
        return height * aspectRatio;
    }

    // calculate height given width, where aspect ratio is width/height.
    float Height(float width, float aspectRatio)
    {
        return width / aspectRatio;
    }

    // calculate aspect ratio, where aspect ratio is width/height.
    float AspectRatio(float width, float height)
    {
        return width / height;
    }

	void Update ()
	{

	}
}

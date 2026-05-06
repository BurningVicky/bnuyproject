using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxBackground : MonoBehaviour
{
    private Camera mainCamera;
    private float lastCameraPositionX;
    private float cameraHalfWidth;


    [SerializeField] private ParallaxLayer[] backgroundLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        CalculateImageLength();
    }

    private void FixedUpdate()
    {
        float CurrentCameraPositionX = mainCamera.transform.position.x;
        float distanceToMove = CurrentCameraPositionX - lastCameraPositionX;
        lastCameraPositionX = CurrentCameraPositionX;

        float cameraLeftEdge = CurrentCameraPositionX - cameraHalfWidth;
        float cameraRightEdge = CurrentCameraPositionX + cameraHalfWidth;

        foreach(ParallaxLayer layer in backgroundLayers)
        {
            layer.Move(distanceToMove);
            layer.LoopBackground(cameraLeftEdge, cameraRightEdge);
        }
    }

    private void CalculateImageLength()
    {
        foreach(ParallaxLayer layer in backgroundLayers)
            layer.CalculateImageWidth();
    }
}

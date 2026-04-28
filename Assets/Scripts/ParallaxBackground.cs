using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera mainCamera;
    private float lastCameraPositionX;


    [SerializeField] private ParallaxLayer[] backgroundLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float CurrentCameraPositionX = mainCamera.transform.position.x;
        float distanceToMove = CurrentCameraPositionX - lastCameraPositionX;
        lastCameraPositionX = CurrentCameraPositionX;

        foreach(ParallaxLayer layer in backgroundLayers)
        {
            layer.Move(distanceToMove);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMenuController : MonoBehaviour
{
    public CinemachineVirtualCamera menuCamera;
    public GameObject objCamera;

    public void AtualizarCamera()
    {
        menuCamera.Follow = objCamera.transform;
        menuCamera.LookAt = objCamera.transform;
    }
}

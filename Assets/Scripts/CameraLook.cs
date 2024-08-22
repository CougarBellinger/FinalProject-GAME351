using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLook : MonoBehaviour
{
    private float maxValue = 1.10f;
    private float minValue = 0.90f;
    private float currentValue;
    public float sensitivity = 1.5f;
    public CinemachineVirtualCamera cmVirtualCam;
    private CinemachineComposer comp;

    void Start()
    {
        //cmVirtualCam = GameObject.GetComponent<CinemachineVirtualCamera>();
        comp = cmVirtualCam.GetCinemachineComponent<CinemachineComposer>();
        comp.m_TrackedObjectOffset.y = 1f;
        currentValue = comp.m_TrackedObjectOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y");
        float final = currentValue + (mouseY * sensitivity);

        final = Mathf.Clamp(final, minValue, maxValue);
        comp.m_TrackedObjectOffset.y = final;
        currentValue = comp.m_TrackedObjectOffset.y;
    }
}

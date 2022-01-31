using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xrange = 5f;
    [SerializeField] float yrange = 3.5f;

    [SerializeField] float positionPitchFactor;
    [SerializeField] float positionYawFactor;
    [SerializeField] float positionRollFactor;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor;
        float yaw = 30f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xrange, xrange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yrange, yrange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}

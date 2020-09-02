using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    [SerializeField] GameObject[] guns;

    [Tooltip("In ms")] [SerializeField] float Speed = 20f;
    [Tooltip("In meter")] [SerializeField] float xRange = 5.5f;
    [Tooltip("In meter")] [SerializeField] float yRange = 3.5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 5f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    bool isControlEnabled = true; //control enable = player alive, control disabled = player dead or colliding

    // Update is called once per frame
    void Update() {
        if (isControlEnabled) {
            ProcessMovement();
            ProcessRotation();
            ProcessFiringBullets();
        }
    }

    private void StopMovementOnDeath() {
        isControlEnabled = false;
    }

    private void ProcessMovement() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);//move the ship
    }

    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        //float yaw = (transform.localPosition.x * Time.deltaTime); //y axes (left right)
        float roll = xThrow * controlRollFactor; //z axes (wing left and right)

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiringBullets() {
        if (CrossPlatformInputManager.GetButton("Fire")) {
            setFireActiveDisable(true);
        } else {
            setFireActiveDisable(false);
        }
    }

    private void setFireActiveDisable(bool isActive) {
        foreach (GameObject gun in guns) {
            var laserParticle = gun.GetComponent<ParticleSystem>().emission;
            laserParticle.enabled = isActive;
        }
    }
}

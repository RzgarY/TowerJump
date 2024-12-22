using System.Collections;
using UnityEngine;

public class PlatformDeactivator : MonoBehaviour
{
    public float deactivationTime = 5f; // Total time before the platform deactivates
    public float blinkTime = 2f; // Time to start blinking
    public Color blinkColor = Color.red; // Color for the blink

    private Renderer platformRenderer;
    private Color originalColor;
    private bool isTriggered = false;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        if (platformRenderer != null)
        {
            originalColor = platformRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(DeactivatePlatform());
        }
    }

    private IEnumerator DeactivatePlatform()
    {
        float elapsedTime = 0f;

        // Wait until it's time to start blinking
        while (elapsedTime < deactivationTime - blinkTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Start blinking
        float blinkElapsed = 0f;
        while (blinkElapsed < blinkTime)
        {
            blinkElapsed += Time.deltaTime;
            platformRenderer.material.color = (blinkElapsed % 0.1f < 0.05f) ? blinkColor : originalColor;
            yield return null;
        }

        // Reset to original color before falling
        platformRenderer.material.color = originalColor;

        // Make the platform fall
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        // Optionally destroy the platform after it falls
        Destroy(gameObject, 5f); // Adjust delay as needed
    }
}

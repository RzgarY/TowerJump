using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this if you're using UI elements

public class TriggerUIHandler : MonoBehaviour
{
    public GameObject uiElement; // The UI element to activate
    public float deactivateDelay = 3f; // Time in seconds before deactivating the UI

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the collider is the player
        if (other.CompareTag("Player"))
        {
            ActivateUI();
        }
    }

    private void ActivateUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(true);
            StartCoroutine(DeactivateUIAfterDelay());
        }
    }

    private IEnumerator DeactivateUIAfterDelay()
    {
        yield return new WaitForSeconds(deactivateDelay);

        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
    }
}

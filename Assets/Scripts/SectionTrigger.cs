using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] easyPrefabs; // Array for easy level prefabs
    public GameObject[] mediumPrefabs; // Array for medium level prefabs
    public GameObject[] hardPrefabs; // Array for hard level prefabs

    private int level = 1; // Tracks the current level
    private float currentYPosition = 40f; // Keeps track of the Y position for the next section

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            GameObject selectedPrefab = SelectPrefab();
            // Instantiate the selected prefab at the current Y position
            Instantiate(selectedPrefab, new Vector3(0, currentYPosition, 0), Quaternion.identity);
            currentYPosition += 40f; // Increase the Y position by 40 for the next section
            level++; // Increase the level as player progresses
        }
    }

    private GameObject SelectPrefab()
    {
        if (level <= 3)
        {
            // Easy prefabs for levels 1-3
            return easyPrefabs[Random.Range(0, easyPrefabs.Length)];
        }
        else if (level <= 7)
        {
            // Medium prefabs for levels 4-7
            return mediumPrefabs[Random.Range(0, mediumPrefabs.Length)];
        }
        else
        {
            // Mix of medium and hard prefabs for levels 8+
            GameObject[] mixedPrefabs = new GameObject[mediumPrefabs.Length + hardPrefabs.Length];
            mediumPrefabs.CopyTo(mixedPrefabs, 0);
            hardPrefabs.CopyTo(mixedPrefabs, mediumPrefabs.Length);
            return mixedPrefabs[Random.Range(0, mixedPrefabs.Length)];
        }
    }
}

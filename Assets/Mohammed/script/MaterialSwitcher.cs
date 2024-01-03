using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    private Renderer rend;
    public Material material1; // Assigned in the Inspector
    public Material material2; // Assigned in the Inspector
    public float switchInterval = 1f; // Time interval for switching materials
    private float elapsedTime = 0f;
    private bool useMaterial1 = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (material1 == null || material2 == null)
        {
            Debug.LogError("Materials not assigned to MaterialSwitcher on " + gameObject.name);
        }

        // Set the initial material
        rend.material = useMaterial1 ? material1 : material2;
    }

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time exceeds the switch interval
        if (elapsedTime >= switchInterval)
        {
            // Reset the elapsed time
            elapsedTime = 0f;

            // Toggle between material1 and material2
            useMaterial1 = !useMaterial1;

            // Apply the new material
            rend.material = useMaterial1 ? material1 : material2;
        }
    }
}

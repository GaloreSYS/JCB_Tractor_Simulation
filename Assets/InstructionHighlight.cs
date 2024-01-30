using UnityEngine;
using System.Collections;

public class InstructionHighlight : MonoBehaviour
{
    public Material materialToBlink; // Assign this through the inspector
    private Color originalColor;
    public Color blinkColor = Color.yellow;
    private Coroutine blinkCoroutine;

    void Start()
    {
        materialToBlink = GetComponent<MeshRenderer>().material;
        if (materialToBlink != null)
        {
            originalColor = materialToBlink.color; // Save the original color of the material
        }
        else
        {
            Debug.LogError("Material to blink is not assigned.");
        }
        gameObject.GetComponent<MeshRenderer>().enabled =false;
    }

    // Call this function to start blinking
    public void StartBlinking()
    {
        if (blinkCoroutine == null)
        {
            gameObject.GetComponent<MeshRenderer>().enabled =true;
            blinkCoroutine = StartCoroutine(BlinkMaterialColor());
        }
    }

    // Call this function to stop blinking
    public void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            ResetColor(); // Reset the color to original when stopped
        }
    }

    private IEnumerator BlinkMaterialColor()
    {
        while (true)
        {
            // Change color to yellow, preserving original alpha
            materialToBlink.color = blinkColor;
            yield return new WaitForSeconds(1f); // Wait for 1 second

            // Change back to original color
            materialToBlink.color = originalColor;
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }
    }

    private void ResetColor()
    {
        gameObject.GetComponent<MeshRenderer>().enabled =false;
        if (materialToBlink != null)
        {
            materialToBlink.color = originalColor;
        }
    }
}
using System.Collections;
using UnityEngine;
using TMPro; // Import TextMeshPro

// Base code from: https://medium.com/@joshua.wiscaver/creating-a-typing-effect-in-unity-2b2526fdc427

public class TypingEffect : MonoBehaviour
{
    public TMP_Text textMeshPro; // Reference to the TextMeshPro component
    public float typingSpeed = 0.1f; // Speed of typing in seconds
    public GameObject appearAfterType;
    public float appearDelay = 3.0f;

    public AudioSource typing;

    private string fullText; // The complete text to be typed

    private void Start()
    {
        appearAfterType.SetActive(false);
        fullText = textMeshPro.text; // Store the full text
        textMeshPro.text = string.Empty; // Clear the text
        StartCoroutine(TypeText()); // Start typing animation
        typing.loop = true;
        typing.Play();
    }

    // Coroutine to simulate typing effect
    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            textMeshPro.text += letter; // Append each letter to the text
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified duration
        }

        typing.Stop();
        yield return new WaitForSeconds(appearDelay);
        appearAfterType.SetActive(true);
    }
}
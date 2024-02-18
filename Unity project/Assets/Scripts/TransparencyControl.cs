using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class TransparencyControl : MonoBehaviour
{
    public GameObject[] objectsToChange;
    public SliderEventData sliderEventData;

    private void Start()
    {
        // Ensure you have attached the On Value Updated event to the method UpdateTransparency
        // in the Unity Editor.
    }

    public void UpdateTransparency(SliderEventData eventData)
    {
        float transparencyValue = eventData.NewValue; // Assuming slider's value ranges from 0 to 1

        foreach (GameObject obj in objectsToChange)
        {
            ChangeObjectTransparency(obj, transparencyValue);
        }
    }

    private void ChangeObjectTransparency(GameObject obj, float transparency)
    {
        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            // Assuming the shader supports transparency via the alpha channel
            Color currentColor = renderer.material.color;
            currentColor.a = transparency;
            renderer.material.color = currentColor;
        }
        else
        {
            Debug.LogError("Renderer component not found on the object: " + obj.name);
        }
    }
}

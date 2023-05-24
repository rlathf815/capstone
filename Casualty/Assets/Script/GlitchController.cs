using UnityEngine;

public class GlitchController : MonoBehaviour
{
    public EditValues editValues;

    public float chromaticGlitchSpeed = 1f;
    public float frameGlitchSpeed = 1f;
    public float pixelGlitchSpeed = 1f;

    private float chromaticGlitch;
    private float frameGlitch;
    private float pixelGlitch;

    private void Start()
    {
        if (editValues == null)
        {
            Debug.LogError("EditValues script reference not set.");
            return;
        }

        chromaticGlitch = editValues.ChromaticGlitch;
        frameGlitch = editValues.FrameGlitch;
        pixelGlitch = editValues.PixelGlitch;
    }

    private void Update()
    {
        // Modify the glitch effect parameters over time using specified speeds
        chromaticGlitch += Time.deltaTime * chromaticGlitchSpeed;
        frameGlitch += Time.deltaTime * frameGlitchSpeed;
        pixelGlitch += Time.deltaTime * pixelGlitchSpeed;

        // Clamp the glitch parameters to the range of [0, 1]
        chromaticGlitch = Mathf.Clamp01(chromaticGlitch);
        frameGlitch = Mathf.Clamp01(frameGlitch);
        pixelGlitch = Mathf.Clamp01(pixelGlitch);

        // Update the glitch effect parameters in the EditValues script
        editValues.ChromaticGlitch = chromaticGlitch;
        editValues.FrameGlitch = frameGlitch;
        editValues.PixelGlitch = pixelGlitch;
    }
}

using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
public class EditValues : MonoBehaviour
{
    [Range(0, 1)]
    public float ChromaticGlitch;

    [Range(0, 1)]
    public float FrameGlitch;

    [Range(0, 1)]
    public float PixelGlitch;

    void Update()
    {
        if (FastGlitchUrp.Instance == null) return;
        FastGlitchUrp.Instance.settings.ChromaticGlitch = ChromaticGlitch;
        FastGlitchUrp.Instance.settings.FrameGlitch = FrameGlitch;
        FastGlitchUrp.Instance.settings.PixelGlitch = PixelGlitch;
        FastGlitchUrp.Instance.Create();
    }
}

namespace UnityEngine.Rendering.Universal
{
    public class FastGlitchUrp : ScriptableRendererFeature
    {
        public static FastGlitchUrp Instance { get; set; }

        [System.Serializable]
        public class FastGlitchSettings
        {
            public RenderPassEvent Event = RenderPassEvent.AfterRenderingTransparents;

            public Material blitMaterial = null;

            [Range(0, 1)]
            public float ChromaticGlitch;

            [Range(0, 1)]
            public float FrameGlitch;

            [Range(0, 1)]
            public float PixelGlitch;
        }

        public FastGlitchSettings settings = new FastGlitchSettings();

        FastGlitchUrpPass mobilePostProcessUrpPass;

        public override void Create()
        {
            mobilePostProcessUrpPass = new FastGlitchUrpPass(settings.Event, settings.blitMaterial, settings.ChromaticGlitch, settings.FrameGlitch, settings.PixelGlitch, this.name);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (Instance == null) Instance = this;
            mobilePostProcessUrpPass.Setup(renderer.cameraColorTarget);
            renderer.EnqueuePass(mobilePostProcessUrpPass);
        }
    }
}

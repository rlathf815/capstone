using UnityEngine.XR;

namespace UnityEngine.Rendering.Universal
{
    internal class FastGlitchUrpPass : ScriptableRenderPass
    {
        public Material material;

        private RenderTargetIdentifier source;
        private RenderTargetIdentifier tempCopy = new RenderTargetIdentifier(tempCopyString);

        private readonly string tag;
        private readonly float chromaticGlitch;
        private readonly float frameGlitch;
        private readonly float pixelGlitch;

        static readonly int amountString = Shader.PropertyToID("_Amount");
        static readonly int frameString = Shader.PropertyToID("_Frame");
        static readonly int pixelString = Shader.PropertyToID("_Pixel");
        static readonly int tempCopyString = Shader.PropertyToID("_TempCopy");
        static readonly string frameKeyword = "FRAME";
        static readonly string pixelKeyword = "PIXEL";

        private Vector2 rand1 = new Vector2(5.0f, 1.0f);
        private Vector2 rand2 = new Vector2(31.0f, 1.0f);
        private Vector2 randMul2 = new Vector2(127.1f, 311.7f);
        private float t, a, b, c;

        public FastGlitchUrpPass(RenderPassEvent renderPassEvent, Material material, float chromaticGlitch, float frameGlitch, float pixelGlitch, string tag)
        {
            this.renderPassEvent = renderPassEvent;
            this.tag = tag;
            this.material = material;
            this.chromaticGlitch = chromaticGlitch;
            this.frameGlitch = frameGlitch;
            this.pixelGlitch = pixelGlitch;
        }

        public void Setup(RenderTargetIdentifier source)
        {
            this.source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var opaqueDesc = XRSettings.enabled ? XRSettings.eyeTextureDesc : renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;

            CommandBuffer cmd = CommandBufferPool.Get(tag);
            cmd.GetTemporaryRT(tempCopyString, opaqueDesc, FilterMode.Bilinear);
            cmd.Blit(source, tempCopy);

            t = Time.realtimeSinceStartup;
            if (chromaticGlitch != 0)
            {
                a = (1.0f + Mathf.Sin(t * 6.0f)) * ((0.5f + Mathf.Sin(t * 16.0f) * 0.25f)) * (0.5f + Mathf.Sin(t * 19.0f) * 0.25f) * (0.5f + Mathf.Sin(t * 27.0f) * 0.25f);
                material.SetFloat(amountString, chromaticGlitch * Mathf.Pow(a, 3.0f) * 0.5f);
            }
            else
                material.SetFloat(amountString, 0f);

            if (frameGlitch != 0)
            {
                material.SetFloat(frameString, (1.0f + Mathf.Cos(t * 80.0f)) * 0.02f * frameGlitch);
                material.EnableKeyword(frameKeyword);
            }
            else
                material.DisableKeyword(frameKeyword);

            if (pixelGlitch != 0)
            {
                b = Mathf.Sin(Vector2.Dot(rand1 * Mathf.Floor(t * 12.0f), randMul2)) * 43758.5453123f;
                c = Mathf.Sin(Vector2.Dot(rand2 * Mathf.Floor(t * 12.0f), randMul2)) * 43758.5453123f;
                material.SetVector(pixelString, new Vector2((b - Mathf.Floor(b)) * pixelGlitch * 0.1f, (c - Mathf.Floor(c)) * pixelGlitch * 0.1f));
                material.EnableKeyword(pixelKeyword);
            }
            else
                material.DisableKeyword(pixelKeyword);

            cmd.Blit(tempCopy, source, material);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(tempCopyString);
        }
    }
}
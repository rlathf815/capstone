Shader "Custom/URPRainShader"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _TintColor("Tint Color", Color) = (1, 1, 1, 1)
    }

        SubShader
        {
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fog

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS   : POSITION;
                    float2 uv           : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct Varyings
                {
                    float4 positionCS   : SV_POSITION;
                    float2 uv           : TEXCOORD0;
                    UNITY_VERTEX_OUTPUT_STEREO
                };

                half4 _TintColor;
                TEXTURE2D(_MainTex);
                SAMPLER(sampler_MainTex);

                Varyings vert(Attributes IN)
                {
                    Varyings OUT;
                    UNITY_SETUP_INSTANCE_ID(IN);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                    OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = IN.uv;

                    return OUT;
                }

                half4 frag(Varyings IN) : SV_Target
                {
                    half4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                    color.rgb *= _TintColor.rgb;
                    color.a *= _TintColor.a;
                    return color;
                }
                ENDHLSL
            }
        }
}

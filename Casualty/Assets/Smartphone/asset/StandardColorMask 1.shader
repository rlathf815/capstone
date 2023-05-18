Shader "VertexStudio/FurnitureColorMask1" {
    Properties{
        [NoScaleOffset] _Mask("Mask (RGB)", 2D) = "black" {}
        [NoScaleOffset] _MainTex("Diffuse", 2D) = "white" {}
        [NoScaleOffset] _Spec("Specular", 2D) = "black" {}
        [NoScaleOffset] _Normal("Normal", 2D) = "bump" {}
        [NoScaleOffset] _OcclusionMap("Ambient Occlusion", 2D) = "white" {}
        _OcclusionStrength("AO intensity", Range(0.0, 1.0)) = 1.0
        [NoScaleOffset] _Emission("Emission", 2D) = "white" {}
        _ColorR("Color (R)", Color) = (1,1,1,1)
        _ColorG("Color (G)", Color) = (1,1,1,1)
        _ColorB("Color (B)", Color) = (1,1,1,1)
        [HDR] _EmissionColor("EmissionColor", Color) = (0,0,0)
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            Pipeline {
                HLSLShader "UniversalForwardPass"
                Blend Off
                Cull Back
                ZWrite On
                ZTest LEqual
                ColorMask RGB
            }

            Pass {
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                #include "Lighting.cginc"

                sampler2D _MainTex;
                sampler2D _Mask;
                sampler2D _Normal;
                sampler2D _Spec;
                sampler2D _Emission;
                sampler2D _OcclusionMap;

                float4 _ColorR;
                float4 _ColorG;
                float4 _ColorB;
                float _OcclusionStrength;
                float4 _EmissionColor;

                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 uv_MainTex : TEXCOORD0;
                };

                struct v2f {
                    float2 uv_MainTex : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                    float4 vertex : SV_POSITION;
                    float4 color : COLOR;
                    float3 worldPos : TEXCOORD1;
                    float3 worldNormal : TEXCOORD2;
                    float2 uv_Mask : TEXCOORD3;
                };

                v2f vert(appdata_t v) {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    o.worldNormal = UnityObjectToWorldNormal(v.normal);
                    o.uv_MainTex = v.uv_MainTex;
                    o.uv_Mask = v.uv_MainTex;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    fixed4 mask = tex2D(_Mask, i.uv_Mask);
                    fixed4 c = tex2D(_MainTex, i.uv_MainTex) * saturate((_ColorR * mask.r + _ColorG * mask.g + _ColorB * mask.b));

                    fixed4 spec = tex2D(_Spec, i.uv_MainTex);
                    fixed4 emission =

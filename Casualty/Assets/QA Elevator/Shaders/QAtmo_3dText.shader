// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "QAtmo/QAtmo_3dTextURP"
{
    Properties
    {
        _MaskClipValue("Mask Clip Value", Float) = 0.5
        _Font("Font", 2D) = "white" {}
        _EmissionIntensity("Emission Intensity", Float) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "TransparentCutout" "Queue" = "AlphaTest+0" "IsEmissive" = "true" }

            Pass
            {
                Tags { "LightMode" = "UniversalForward" }
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fog

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS   : POSITION;
                    float2 uv           : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionCS   : SV_POSITION;
                    float2 uv           : TEXCOORD0;
                };

                TEXTURE2D(_Font);
                SAMPLER(sampler_Font);
                float4 _Font_ST;
                float _EmissionIntensity;
                float _MaskClipValue;

                Varyings vert(Attributes v)
                {
                    Varyings o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_TRANSFER_INSTANCE_ID(v, o);
                    o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
                    o.uv = TRANSFORM_TEX(v.uv, _Font);
                    return o;
                }

                half4 frag(Varyings i) : SV_Target
                {
                    half4 color = SAMPLE_TEXTURE2D(_Font, sampler_Font, i.uv);
                    color.rgb = half3(1, 1, 1); // hard code the color to light green
                    half emission = _EmissionIntensity * color.a;
                    color.rgb = color.rgb * emission;
                    clip(color.a - _MaskClipValue);
                    return color;
                }
                ENDHLSL
            }
        }
}
/*ASEBEGIN
Version=12001
202;255;1301;662;1086.001;510.4003;1.3;True;True
Node;AmplifyShaderEditor.VertexColorNode;1;-676.2996,-379.1;Float;False;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;-659.2002,72.19988;Float;True;Property;_Font;Font;1;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;7;-407.9995,-86.89998;Float;False;Property;_EmissionIntensity;Emission Intensity;2;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-265.2,58.39981;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-91.39948,-114.2001;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;124,-170.7;Float;False;True;2;Float;ASEMaterialInspector;0;Standard;QAtmo/QAtmo_3dText;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Masked;0.5;True;False;0;False;TransparentCutout;AlphaTest;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;1;4
WireConnection;4;1;2;4
WireConnection;5;0;1;0
WireConnection;5;1;7;0
WireConnection;0;0;1;0
WireConnection;0;2;5;0
WireConnection;0;10;4;0
ASEEND*/
//CHKSM=95D7EC07FD07809B775D99FBD73FD560016BE252
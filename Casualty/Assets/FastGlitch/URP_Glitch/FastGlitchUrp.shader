Shader "RufatShaderlab/GlitchUrp"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "" {}
	}

	HLSLINCLUDE

	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

	TEXTURE2D_X(_MainTex);
	SAMPLER(sampler_MainTex);
	half _Amount;
	half _Frame;
	half2 _Pixel;
	half4 _MainTex_TexelSize;

	struct appdata
	{
		half4 pos : POSITION;
		half2 uv : TEXCOORD0;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};

	struct v2f
	{
		half4 pos : POSITION;
		half4 uv : TEXCOORD0;
#ifdef PIXEL
		half4 uv1 : TEXCOORD1;
#endif
		UNITY_VERTEX_OUTPUT_STEREO
	};

	half r(half2 v)
	{
		return frac(sin(dot(v * floor(_Time.y * 12.0h), half2(127.1h, 311.7h))) * 43758.5453123h);
	}

	v2f vert(appdata i)
	{
		v2f o = (v2f)0;
		UNITY_SETUP_INSTANCE_ID(i);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		o.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, half4(i.pos.xyz, 1.0h)));
		o.uv.xy = UnityStereoTransformScreenSpaceTex(i.uv);
		o.uv.zw = half2(o.uv.x + _Amount, o.uv.x - _Amount);
#ifdef PIXEL
		o.uv1 = floor(half4(i.uv.xy * half2(24.0h, 9.0h), i.uv.xy * half2(8.0h, 4.0h)));
#endif
		return o;
	}

	half4 frag(v2f i) : COLOR
	{
		UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
#ifdef FRAME
		i.uv.xwz += sin(i.uv.y * 10.0h + _Time.y) * step(0.3h, sin(_Time.y + 4.0h * _CosTime.w)) * _Frame;
#endif
#ifdef PIXEL
		half lineNoise = pow(r(floor(i.uv1.xy)), 8.0) * pow(r(floor(i.uv1.zw)), 3.0);
		i.uv.x += lineNoise * _Pixel.x;
		i.uv.w -= lineNoise * _Pixel.y;
#endif
		return half4(SAMPLE_TEXTURE2D_X(_MainTex, sampler_MainTex, i.uv.zy).r, SAMPLE_TEXTURE2D_X(_MainTex, sampler_MainTex, i.uv.xy).g, SAMPLE_TEXTURE2D_X(_MainTex, sampler_MainTex, i.uv.wy).b, 1.0h);
	}
	ENDHLSL

	Subshader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off
			Fog { Mode off }
			HLSLPROGRAM
			#pragma shader_feature_local FRAME
			#pragma shader_feature_local PIXEL
			#pragma vertex vert
			#pragma fragment frag
			ENDHLSL
		}
	}
	Fallback off
}
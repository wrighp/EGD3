Shader "Custom/Fur10"
{
	Properties
	{
		_FurLength("Fur Length", Range(.0002, 1)) = .25
		_NoiseTex("Noise (R)", 2D) = "white" { }
	_ColorTex("Color (RGB)", 2D) = "white" { }
	_Cutoff("Alpha Cutoff", Range(0, 1)) = .0001
		_EdgeFade("Edge Fade", Range(0,1)) = 0.4
		_LightDirection0("Light Direction 0, Ambient", Vector) = (1,1,0,1)
		_MyLightColor0("Light Color 0", Color) = (1,1,1,1)
		//_LightDirection1 ("Light Direction 1, Ambient", Vector) = (1,0,0,1)
		//_MyLightColor1 ("Light Color 1", Color) = (1,1,1,1)
		_Gravity("Gravity Vector" , Vector) = (0, -1, 0, 0)
		_ForceDirection("Force Vector", Vector) = (0,0,0,0)
	}

		SubShader
	{

		/*Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		//Blend One One
		Alphatest Greater[_Cutoff]*/

		Tags{ "RenderType" = "Transparent" "IgnoreProjector" = "True" "RenderQueue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		Cull Off

		Pass
	{
		//ZWrite On


		Tags{ "LightMode" = "ForwardBase" "RenderType" = "Opaque" }
		ZWrite On
		Blend Off

		CGPROGRAM
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.0
#include "FurShader00_shared.cginc"
		ENDCG
	}

		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.1
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.2
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.3
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.4
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.5
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#pragma vertex VertexProgram
#pragma fragment FragmentProgram
#define FUR_MULTIPLIER 0.6
#include "FurShader00_shared.cginc"
		ENDCG
	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#define FUR_MULTIPLIER 0.7
#pragma vertex VertexProgram
#pragma fragment FragmentProgram

#include "FurShader00_shared.cginc"
		ENDCG

	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#define FUR_MULTIPLIER 0.8
#pragma vertex VertexProgram
#pragma fragment FragmentProgram      
#include "FurShader00_shared.cginc"
		ENDCG

	}
		
		Pass
	{
		CGPROGRAM
		// vertex VertexProgram
#define FUR_MULTIPLIER 0.9
#pragma vertex VertexProgram
#pragma fragment FragmentProgram          
#include "FurShader00_shared.cginc"
		ENDCG

	}
		
	}
}
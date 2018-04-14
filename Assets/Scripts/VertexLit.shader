// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/VertexLit"
{
	SubShader
	{
		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest


	struct vInput
	{
		float4 vertex : POSITION;
		float4 color : COLOR;
	};

	struct vOutput
	{
		float4 pos :SV_POSITION;
		float4 color :TEXCOORD0;
	};


	vOutput vert(vInput v)
	{
		vOutput o;

		o.pos = UnityObjectToClipPos(v.vertex);

		o.color = v.color;

		return o;
	}

	float4 frag(vOutput i) : COLOR
	{
		return i.color;
	}

		ENDCG

	} //Pass
	} //SubShader
} //Shader
#ifndef FURSHADER00_SHARED_INCLUDED
#define FURSHADER00_SHARED_INCLUDED


#include "UnityCG.cginc"
#include "UnityLightingCommon.cginc"

struct v2f {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
	float4 uv : TEXCOORD0;
};

uniform float _FurLength;
uniform float _EdgeFade;
uniform float4 _LightDirection0;
uniform float4 _MyLightColor0;
uniform float3 _Gravity;
uniform float3 _ForceDirection;

sampler2D _NoiseTex : register(s0);
sampler2D _ColorTex : register(s1);
float4 _NoiseTex_ST;
float4 _ColorTex_ST;

void FurVertexPass(float multiplier, appdata_base v, float furLength, out float4 pos, out float4 color, out float4 uv)
{
	// extrude position
	float4 wpos = v.vertex;
	wpos.xyz += v.normal * furLength * multiplier;
	pos = UnityObjectToClipPos(wpos);

	//make the displacement non linear, to make it look more like fur
	float displacementFactor = pow((multiplier), 3);
	//apply the displacement
	pos.xyz += (_Gravity + _ForceDirection)*displacementFactor;

	// UV (pass through to save instructions - loses tiling/offset though)
	uv = v.texcoord;

	// edge fade out
	float alpha = 1 - multiplier*multiplier;

	float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));

	alpha += dot(viewDir, v.normal) - _EdgeFade;

	// lighting
	float3 normalWorld = UnityObjectToWorldNormal(v.normal);

	half nl0 = clamp(dot(normalWorld, _LightDirection0.xyz), _LightDirection0.w, 1);

	color = float4((nl0 * _MyLightColor0).xyz, alpha);

	//based on layer depth, choose the amount of shading.
	//we lerp between two values to avoid having the base of the fur pure black.
	float shadow = lerp(0.4, 1, multiplier);
	color *= shadow;
}


v2f VertexProgram(appdata_base v)
{
	v2f o;
	FurVertexPass(FUR_MULTIPLIER, v, _FurLength, o.pos, o.color, o.uv);
	return o;
}

float4 FragmentProgram(v2f o) : SV_TARGET
{
	float4 TextureNoise = tex2D(_NoiseTex, o.uv * _NoiseTex_ST.xy);
	float4 TextureColor = tex2D(_ColorTex, o.uv * _ColorTex_ST.xy);
	return float4(o.color.r*TextureColor.r, o.color.g*TextureColor.g, o.color.b*TextureColor.b, o.color.a*TextureNoise.r);
}

#endif
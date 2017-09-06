// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#ifndef COCOCG_TOON
#define COCOCG_TOON

// pragmas -------------------------------------
#include "UnityCG.cginc"


// custom -------------------------------------
#ifndef COCO_APPDATA
	#define COCO_APPDATA
#endif
#ifndef COCO_V2F
	#define COCO_V2F
#endif
#ifndef COCO_VERT
	#define COCO_VERT
#endif
#ifndef COCO_FRAG
	#define COCO_FRAG(tex, col) tex *= col;
#endif

// properties -------------------------------------
sampler2D _MainTex;
samplerCUBE _ToonShade;
float4 _MainTex_ST;
float4 _Color;

#ifdef COCO_USE_ALPHA_CLIP
	fixed _Cutoff;
#endif


// structs -------------------------------------
struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD0;
	COCO_APPDATA
};

struct v2f {
	float4 pos : POSITION;
	float2 texcoord : TEXCOORD0;
	float3 cubenormal : TEXCOORD1;
	COCO_V2F
};


// vertex function -------------------------------------
v2f vert (appdata v)
{
	v2f o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	o.cubenormal = mul (UNITY_MATRIX_MV, float4(v.normal,0));

	COCO_VERT

	return o;
}


// fragment function  -------------------------------------
float4 frag (v2f i) : COLOR
{
	float4 tex = tex2D(_MainTex, i.texcoord);
	float4 cube = texCUBE(_ToonShade, i.cubenormal);

	COCO_FRAG(tex, _Color)

	#ifdef COCO_USE_ALPHA_CLIP
		clip(tex.a - _Cutoff);
	#endif

	return float4(2.0f * cube.rgb * tex.rgb, tex.a);
}


#endif

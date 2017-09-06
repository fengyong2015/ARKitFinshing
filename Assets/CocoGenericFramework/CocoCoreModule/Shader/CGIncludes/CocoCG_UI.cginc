// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#ifndef COCOCG_UI
#define COCOCG_UI

// pragmas -------------------------------------
#include "UnityCG.cginc"
#include "UnityUI.cginc"


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
fixed4 _Color;
fixed4 _TextureSampleAdd;
float4 _ClipRect;


// structs -------------------------------------
struct appdata_t
{
	float4 vertex   : POSITION;
	float4 color    : COLOR;
	float2 texcoord : TEXCOORD0;
	COCO_APPDATA
};

struct v2f
{
	float4 vertex   : SV_POSITION;
	fixed4 color    : COLOR;
	half2 texcoord  : TEXCOORD0;
	float4 worldPosition : TEXCOORD1;
	COCO_V2F
};


// vertex function -------------------------------------
v2f vert(appdata_t IN)
{
	v2f OUT;
	OUT.worldPosition = IN.vertex;
	OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

	OUT.texcoord = IN.texcoord;

	#ifdef UNITY_HALF_TEXEL_OFFSET
	OUT.vertex.xy += (_ScreenParams.zw-1.0) * float2(-1,1) * OUT.vertex.w;
	#endif

	OUT.color = IN.color * _Color;

	COCO_VERT

	return OUT;
}


// fragment function  -------------------------------------
fixed4 frag(v2f IN) : SV_Target
{
	half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd);
	
	COCO_FRAG(color, IN.color)

	color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);

	#ifdef UNITY_UI_ALPHACLIP
	clip (color.a - 0.001);
	#endif

	return color;
}


#endif

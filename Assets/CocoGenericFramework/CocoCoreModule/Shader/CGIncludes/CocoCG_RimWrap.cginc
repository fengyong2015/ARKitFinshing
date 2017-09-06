#ifndef COCOCG_RIM_WRAP
#define COCOCG_RIM_WRAP


// pragmas -------------------------------------
#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Light.cginc"

// custom -------------------------------------
#ifndef COCO_INPUTDATA
	#define COCO_INPUTDATA
#endif
#ifndef COCO_SURF
	#define COCO_SURF(tex, col) tex *= col;
#endif



// properties -------------------------------------
float4 _Color;
sampler2D _MainTex;


// structs -------------------------------------
struct Input {
	half2 uv_MainTex;
	half3 viewDir;
	COCO_INPUTDATA
};


// surface function -------------------------------------
void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D (_MainTex, IN.uv_MainTex);

	COCO_SURF(tex, _Color)

	o.Albedo = tex.rgb;
	o.Alpha = tex.a;

	o.Emission = rim (IN.viewDir, o.Normal);
}

#endif

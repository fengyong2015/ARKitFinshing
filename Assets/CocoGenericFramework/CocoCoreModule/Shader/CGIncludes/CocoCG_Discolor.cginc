#ifndef COCOCG_DISCOLOR
#define COCOCG_DISCOLOR

// pragmas -------------------------------------
#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Color.cginc"

#ifndef COCO_DISCOLOR_ONLY_HUE
	half _Hue;
	half _Saturation;
	half _Lightness;
	half _MixingFactor;
#else	// #ifndef COCO_DISCOLOR_ONLY_HUE
	float4 _Hue;
	half _SaturMin;
	half _SaturRatio;
	half _SaturAdd;
	half _LightMax;
	half _LightRatio;
	half _LightAdd;
#endif	// #ifndef COCO_DISCOLOR_ONLY_HUE


// datas -------------------------------------
#ifndef COCO_APPDATA_DISCOLOR
	#define COCO_APPDATA_DISCOLOR
#endif

#ifndef COCO_V2F_DISCOLOR
	#define COCO_V2F_DISCOLOR
#endif

// custom function -------------------------------------
#ifndef COCO_VERT_DISCOLOR
	#define COCO_VERT_DISCOLOR
#endif

#ifndef COCO_FRAG_DISCOLOR
	#ifndef COCO_DISCOLOR_ONLY_HUE
		#define COCO_FRAG_DISCOLOR(tex) tex.rgb = blend_hsl_to_rgb (tex.rgb, _Hue, _Saturation, _Lightness) * _MixingFactor;
	#else	// #ifndef COCO_DISCOLOR_ONLY_HUE
		#define COCO_FRAG_DISCOLOR(tex) if (_Hue.a > 0.01) {\
				float3 hsl = rgb_to_hsl (_Hue.rgb);\
				tex.rgb = replace_hue_by_hsl_fix (tex.rgb, hsl.x, _SaturMin, _SaturRatio, _SaturAdd, _LightMax, _LightRatio, _LightAdd);\
			}
	#endif	// #ifndef COCO_DISCOLOR_ONLY_HUE
#endif

#endif

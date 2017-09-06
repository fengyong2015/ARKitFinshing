#ifndef COCOCG_TEXLAYER
#define COCOCG_TEXLAYER


// pragmas -------------------------------------
#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Util.cginc"

#define COCO_LAYER_VAR(idx) sampler2D _LayerTex##idx;
#define COCO_LAYER_VAR_INPUT(idx) half2 uv_LayerTex##idx;

// properties -------------------------------------
#ifdef COCO_USE_3LAYER
	COCO_LAYER_VAR(1) COCO_LAYER_VAR(2) COCO_LAYER_VAR(3)
#else
	#ifdef COCO_USE_2LAYER
		COCO_LAYER_VAR(1) COCO_LAYER_VAR(2)
	#else
		#ifdef COCO_USE_1LAYER
			COCO_LAYER_VAR(1)
		#endif
	#endif
#endif


// structs -------------------------------------
#ifndef COCO_INPUTDATA_TEXLAYER
	#ifdef COCO_USE_3LAYER
		#define COCO_INPUTDATA_TEXLAYER COCO_LAYER_VAR_INPUT(1) COCO_LAYER_VAR_INPUT(2) COCO_LAYER_VAR_INPUT(3)
	#else
		#ifdef COCO_USE_2LAYER
			#define COCO_INPUTDATA_TEXLAYER COCO_LAYER_VAR_INPUT(1) COCO_LAYER_VAR_INPUT(2)
		#else
			#ifdef COCO_USE_1LAYER
				#define COCO_INPUTDATA_TEXLAYER COCO_LAYER_VAR_INPUT(1)
			#endif
		#endif
	#endif
#endif


// custom functions -------------------------------------
#ifndef COCO_SURF_TEXLAYER
	#ifdef COCO_USE_3LAYER
		#define COCO_SURF_TEXLAYER(tex) \
			fixed4 layer1 = tex2D (_LayerTex1, IN.uv_LayerTex1);\
			fixed4 layer2 = tex2D (_LayerTex2, IN.uv_LayerTex2);\
			fixed4 layer3 = tex2D (_LayerTex3, IN.uv_LayerTex3);\
			tex.rgb = blend_layer3_to_color (tex, layer1, layer2, layer3);
	#else
		#ifdef COCO_USE_2LAYER
			#define COCO_SURF_TEXLAYER(tex) \
				fixed4 layer1 = tex2D (_LayerTex1, IN.uv_LayerTex1);\
				fixed4 layer2 = tex2D (_LayerTex2, IN.uv_LayerTex2);\
				tex.rgb = blend_layer2_to_color (tex, layer1, layer2);
		#else
			#ifdef COCO_USE_1LAYER
				#define COCO_SURF_TEXLAYER(tex) \
					fixed4 layer1 = tex2D (_LayerTex1, IN.uv_LayerTex1);\
					tex.rgb = blend_layer_to_color (tex, layer1);
			#endif
		#endif
	#endif
#endif

#endif

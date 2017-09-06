Shader "Coco/RimWrap/Basic (3 Layer (Layer2 UV2))" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Texture", 2D) = "white" {}

		_LayerTex1 ("Layer 1", 2D) = "black" {}
		_LayerTex2 ("Layer 2 (UV2)", 2D) = "black" {}
		_LayerTex3 ("Layer 3", 2D) = "black" {}

		_RimColor ("Rim Color", Color) = (0.392, 0.392, 0.588, 0)
		_RimPower ("Rim Power", Float) = 2

		_WrapPower ("Wrap Power", Float) = 0.5
		_LightPower ("Light Power", Float) = 2
	}

	SubShader {
		Tags { "RenderType" = "Opaque" }
		
		CGPROGRAM
		#pragma surface surf WrapLambert

		#define COCO_USE_3LAYER

		#define COCO_INPUTDATA_TEXLAYER half2 uv_LayerTex1; half2 uv2_LayerTex2; half2 uv_LayerTex3;
		#define COCO_SURF_TEXLAYER(tex) \
			fixed4 layer1 = tex2D (_LayerTex1, IN.uv_LayerTex1);\
			fixed4 layer2 = tex2D (_LayerTex2, IN.uv2_LayerTex2);\
			fixed4 layer3 = tex2D (_LayerTex3, IN.uv_LayerTex3);\
			tex.rgb = blend_layer3_to_color (tex, layer1, layer2, layer3);

		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_TexLayer_Only.cginc"
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_RimWrap.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

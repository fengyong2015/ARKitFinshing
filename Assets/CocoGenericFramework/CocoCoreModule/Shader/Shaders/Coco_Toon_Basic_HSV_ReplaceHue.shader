Shader "Coco/Toon/Basic (HSV, Replace Hue)" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" {}

		// hue
		_Hue ("Color (Hue Only)", Color) = (1, 1, 1, 0)
		_SaturMin ("Saturation Min", Range (0, 1.5)) = 0.1
		_SaturRatio ("Saturation Ratio", Range (-2, 2)) = 2
		_SaturAdd ("Saturation Add", Range (-2, 2)) = 0.05
		_LightMax ("Light Max", Range (0, 2)) = 0.9
		_LightRatio ("Ligh Ratio", Range (-2, 2)) = 2
		_LightAdd ("Light Add", Range (-3, 3)) = 0.5
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		Pass {
			Name "BASE"

			CGPROGRAM

			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0

			#pragma vertex vert
			#pragma fragment frag

			#define COCO_USE_COLOR_HSV
			#define COCO_DISCOLOR_ONLY_HUE
			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Discolor_Only.cginc"
			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Toon.cginc"

			ENDCG
		}
	}

	Fallback "VertexLit"
}

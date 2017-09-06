Shader "Coco/Toon/Transparent Cutout (HSL, Blend)" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" {}
		_Cutoff ("Alpha cutoff", Range (0, 1)) = 0.5

		// hsl
		_Hue ("Hue", Range (-0.5, 0.5)) = 0
		_Saturation ("Saturation", Range (-1, 1)) = 0
		_Lightness ("Lightness", Range (-1, 1)) = 0
		_MixingFactor ("Mixing Factor", Range (0, 4)) = 1
	}


	SubShader {
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}

		Pass {
			Name "BASE"

			CGPROGRAM

			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0

			#pragma vertex vert
			#pragma fragment frag

			#define COCO_USE_ALPHA_CLIP
			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Discolor_Only.cginc"
			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Toon.cginc"

			ENDCG
		}
	}

	Fallback "VertexLit"
}

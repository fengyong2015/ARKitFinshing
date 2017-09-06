Shader "Coco/Toon/Basic" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" {}
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

			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Toon.cginc"

			ENDCG
		}
	}

	Fallback "VertexLit"
}

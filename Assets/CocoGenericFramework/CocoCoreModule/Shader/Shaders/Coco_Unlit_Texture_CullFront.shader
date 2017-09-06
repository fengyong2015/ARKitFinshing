Shader "Coco/Unlit/Texture (Cull Front)" {
	Properties {
		_Color ("Main Color", Color) = (1, 1, 1, 0.5)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 100
        CULL FRONT

		Pass {
			Name "BASE"

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Unlit.cginc"
			ENDCG
		}
	}

	Fallback "VertexLit"
}

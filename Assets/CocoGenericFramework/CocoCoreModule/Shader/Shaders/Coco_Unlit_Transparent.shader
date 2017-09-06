Shader "Coco/Unlit/Transparent" {
	Properties {
		_Color ("Main Color", Color) = (1, 1, 1, 0.5)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 100

		Blend SrcAlpha OneMinusSrcAlpha 
		ZWrite Off

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

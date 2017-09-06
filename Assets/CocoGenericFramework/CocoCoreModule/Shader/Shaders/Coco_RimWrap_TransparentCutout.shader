Shader "Coco/RimWrap/Transparent Cutout" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Texture", 2D) = "white" {}

		_RimColor ("Rim Color", Color) = (0.392, 0.392, 0.588, 0)
		_RimPower ("Rim Power", Float) = 2

		_WrapPower ("Wrap Power", Float) = 0.5
		_LightPower ("Light Power", Float) = 2

		_Cutoff ("Alpha cutoff", Range (0, 1)) = 0.5
	}

	SubShader {
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		
		CGPROGRAM
		#pragma surface surf WrapLambert alphatest:_Cutoff
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_RimWrap.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

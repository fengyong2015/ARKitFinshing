Shader "Coco/RimWrap/Basic (2 Layer)" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_MainTex ("Texture", 2D) = "white" {}

		_LayerTex1 ("Layer 1", 2D) = "black" {}
		_LayerTex2 ("Layer 2", 2D) = "black" {}

		_RimColor ("Rim Color", Color) = (0.392, 0.392, 0.588, 0)
		_RimPower ("Rim Power", Float) = 2

		_WrapPower ("Wrap Power", Float) = 0.5
		_LightPower ("Light Power", Float) = 2
	}

	SubShader {
		Tags { "RenderType" = "Opaque" }
		
		CGPROGRAM
		#define COCO_USE_2LAYER
		#pragma surface surf WrapLambert
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_TexLayer_Only.cginc"
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_RimWrap.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

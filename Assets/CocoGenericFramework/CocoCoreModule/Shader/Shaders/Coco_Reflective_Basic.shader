Shader "Coco/Reflective/Basic" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_MainTex ("Base (RGB) RefStrGloss (A)", 2D) = "black" {}
		_Cube ("Reflection Cubemap", Cube) = "black" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}

        // bottom layer
		_BottomTex ("Bottom Layer", 2D) = "black" {}
		// property
		_PropertyTex ("Blend (R) Alpha (G)", 2D) = "white" {}
	}

	SubShader {
		Tags { "RenderType" = "Opaque" }
		
		CGPROGRAM
		#pragma surface surf BlinnPhong
		#pragma target 3.0
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Reflective.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

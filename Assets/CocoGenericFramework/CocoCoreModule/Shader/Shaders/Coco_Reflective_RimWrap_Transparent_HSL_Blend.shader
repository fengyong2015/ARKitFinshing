Shader "Coco/Reflective RimWrap/Transparent (HSL, Blend)" {
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
		
        // rim wrap
		_RimColor ("Rim Color", Color) = (0.392, 0.392, 0.588, 0)
		_RimPower ("Rim Power", Float) = 2
		_WrapPower ("Wrap Power", Float) = 0.5
		_LightPower ("Light Power", Float) = 2
		
		// hsl
		_Hue ("Hue", Range (-0.5, 0.5)) = 0
		_Saturation ("Saturation", Range (-1, 1)) = 0
		_Lightness ("Lightness", Range (-1, 1)) = 0
		_MixingFactor ("Mixing Factor", Range (0, 4)) = 1
	}

	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		
		CGPROGRAM
		#pragma surface surf WrapLambert alpha
		#pragma target 3.0
		
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Discolor.cginc"
	    #include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Reflective_RimWrap.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

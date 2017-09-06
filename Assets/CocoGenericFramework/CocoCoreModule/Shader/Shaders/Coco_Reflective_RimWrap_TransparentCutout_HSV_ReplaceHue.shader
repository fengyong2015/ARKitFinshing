Shader "Coco/Reflective RimWrap/Transparent Cutout (HSV, Replace Hue)" {
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
		
		// hue
		_Hue ("Color (Hue Only)", Color) = (1, 1, 1, 0)
		_SaturMin ("Saturation Min", Range (0, 1.5)) = 0.1
		_SaturRatio ("Saturation Ratio", Range (-2, 2)) = 2
		_SaturAdd ("Saturation Add", Range (-2, 2)) = 0.05
		_LightMax ("Light Max", Range (0, 2)) = 0.9
		_LightRatio ("Ligh Ratio", Range (-2, 2)) = 2
		_LightAdd ("Light Add", Range (-3, 3)) = 0.5
	
	    _Cutoff ("Alpha cutoff", Range (0, 1)) = 0.5
	}

	SubShader {
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		
		CGPROGRAM
		#pragma surface surf WrapLambert alphatest:_Cutoff
		#pragma target 3.0
		
		#define COCO_USE_COLOR_HSV
		#define COCO_DISCOLOR_ONLY_HUE
		#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Discolor.cginc"
	    #include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Reflective_RimWrap.cginc"
		ENDCG
	}

	FallBack "Diffuse"
}

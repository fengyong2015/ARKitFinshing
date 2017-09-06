#ifndef COCOCG_REFLECTIVE_RIM_WRAP
#define COCOCG_REFLECTIVE_RIM_WRAP


// pragmas -------------------------------------
#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Light.cginc"

// custom -------------------------------------
#ifndef COCO_INPUTDATA
	#define COCO_INPUTDATA
#endif
#ifndef COCO_SURF
	#define COCO_SURF(tex, botTex, col) tex.rgb *= col.rgb; botTex.rgb *= col.rgb;
#endif
#ifndef COCO_SURF_REFL
	#define COCO_SURF_REFL(reflTex, reflCol) reflTex.rgb = reflTex.rgb * reflCol.rgb + rim (IN.viewDir, o.Normal);
#endif

#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Reflective.cginc"

#endif

#ifndef COCOCG_TEXLAYER_ONLY
#define COCOCG_TEXLAYER_ONLY

#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_TexLayer.cginc"

// custom ---------------------------
#define COCO_INPUTDATA COCO_INPUTDATA_TEXLAYER
#define COCO_SURF(tex, col) COCO_SURF_TEXLAYER(tex) tex *= col;
// custom end -----------------------

#endif

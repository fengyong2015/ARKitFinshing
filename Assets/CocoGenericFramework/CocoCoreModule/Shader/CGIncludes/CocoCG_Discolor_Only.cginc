#ifndef COCOCG_DISCOLOR_ONLY
#define COCOCG_DISCOLOR_ONLY

#include "Assets/CocoGenericFramework/CocoCoreModule/Shader/CGIncludes/CocoCG_Discolor.cginc"

// custom ---------------------------
#define COCO_APPDATA COCO_APPDATA_DISCOLOR
#define COCO_V2F COCO_V2F_DISCOLOR
#define COCO_VERT COCO_VERT_DISCOLOR
#define COCO_FRAG(tex, col) COCO_FRAG_DISCOLOR(tex) tex *= col;
// custom end -----------------------

#endif

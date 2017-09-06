#ifndef COCOCG_UTIL
#define COCOCG_UTIL

fixed3 blend_layer_to_color (fixed4 col, fixed4 layer1)
{
	return col.rgb * (1.0 - layer1.a) + layer1.rgb * layer1.a;
}

fixed3 blend_layer2_to_color (fixed4 col, fixed4 layer1, fixed4 layer2)
{
	return col.rgb * (1.0 - layer1.a - layer2.a) + layer1.rgb * layer1.a + layer2.rgb * layer2.a;
}

fixed3 blend_layer3_to_color (fixed4 col, fixed4 layer1, fixed4 layer2, fixed4 layer3)
{
	return col.rgb * (1.0 - layer1.a - layer2.a - layer3.a) + layer1.rgb * layer1.a + layer2.rgb * layer2.a + layer3.rgb * layer3.a;
}

#endif

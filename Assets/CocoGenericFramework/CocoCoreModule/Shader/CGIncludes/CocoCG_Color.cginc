#ifndef COCOCG_COLOR
#define COCOCG_COLOR

#ifndef COCO_USE_COLOR_HSV

// HSL ----------------------------------------------------

float3 rgb_to_hsl(float3 RGB)
{
	float3 HSL;

	float minChannel, maxChannel;
	if (RGB.x > RGB.y) {
		maxChannel = RGB.x;
		minChannel = RGB.y;
	} else {
		maxChannel = RGB.y;
		minChannel = RGB.x;
	}

	if (RGB.z > maxChannel) maxChannel = RGB.z;
	if (RGB.z < minChannel) minChannel = RGB.z;
	
	// L
	HSL.xy = 0;
	HSL.z = (maxChannel + minChannel) / 2;

	// S
	float delta = maxChannel - minChannel;
	if (delta != 0) { 
		if (HSL.z < 0.5) {
			HSL.y = delta / (maxChannel + minChannel);
		} else {
			HSL.y = delta / (2.0 - maxChannel - minChannel);
		}
		
		// H
		float3 del_rgb = ((maxChannel - RGB) / 6.0 + delta / 2.0) / delta;
		if (RGB.x == maxChannel)
			HSL.x = del_rgb.z - del_rgb.y;
		else if (RGB.y == maxChannel)
			HSL.x = 1.0 / 3.0 + del_rgb.x - del_rgb.z;
		else
			HSL.x = 2.0 / 3.0 + del_rgb.y - del_rgb.x;

//		delta *= 6.0;
//		if (RGB.x == maxChannel)
//			HSL.x = (RGB.y - RGB.z) / delta;
//		else if (RGB.y == maxChannel)
//			HSL.x = (2.0 + RGB.z - RGB.x) / delta;
//		else
//			HSL.x = (4.0 + RGB.x - RGB.y) / delta;

		if (HSL.x < 0)
			HSL.x += 1;
		else if (HSL.x > 1)
			HSL.x -= 1;
	}
	
	return (HSL);
}

float h_to_rgb (float t1, float t2, float h)
{
	if (h < 0)
		h += 1;
	if (h > 1)
		h -= 1;
	if (6.0 * h < 1)
		return t1 + (t2 - t1) * 6.0 * h;
	if (2.0 * h < 1)
		return t2;
	if (3.0 * h < 2)
		return t1 + (t2 - t1) * ((2.0 / 3.0) - h) * 6.0;
    return (t1);
}

float3 hsl_to_rgb (float3 HSL)
{
	float3 RGB = float3 (HSL.z, HSL.z, HSL.z);
	
	float temp1, temp2;
	if (HSL.y != 0) {
		if (HSL.z < 0.5)
			temp2 = HSL.z * (1 + HSL.y);
		else
			temp2 = (HSL.z + HSL.y) - (HSL.y * HSL.z);

        temp1 = 2.0 * HSL.z - temp2;

        RGB.x = h_to_rgb (temp1, temp2, HSL.x + (1.0 / 3.0));
        RGB.y = h_to_rgb (temp1, temp2, HSL.x);
        RGB.z = h_to_rgb (temp1, temp2, HSL.x - (1.0 / 3.0));
	}
	
	return RGB;
}

#else	// #!ifdef COCO_USE_COLOR_HSV

float3 rgb_to_hsl(float3 RGB)
{
	float3 HSV;

	float minChannel, maxChannel;
	if (RGB.x > RGB.y) {
		maxChannel = RGB.x;
		minChannel = RGB.y;
	} else {
		maxChannel = RGB.y;
		minChannel = RGB.x;
	}

	if (RGB.z > maxChannel) maxChannel = RGB.z;
	if (RGB.z < minChannel) minChannel = RGB.z;

	HSV.xy = 0;
	HSV.z = maxChannel;
	float delta = maxChannel - minChannel;             //Delta RGB value
	if (delta != 0) {                    // If gray, leave H  S at zero
		HSV.y = delta / HSV.z;
		float3 delRGB;
		delRGB = (HSV.zzz - RGB + 3*delta) / (6.0*delta);
		if      ( RGB.x == HSV.z ) HSV.x = delRGB.z - delRGB.y;
		else if ( RGB.y == HSV.z ) HSV.x = ( 1.0/3.0) + delRGB.x - delRGB.z;
		else if ( RGB.z == HSV.z ) HSV.x = ( 2.0/3.0) + delRGB.y - delRGB.x;
	}
	return (HSV);
}

float3 hsl_to_rgb(float3 HSV)
{
	float3 RGB = HSV.z;

	float var_h = HSV.x * 6;
	float var_i = floor(var_h);   // Or ... var_i = floor( var_h )
	float var_1 = HSV.z * (1.0 - HSV.y);
	float temp2 = HSV.z * (1.0 - HSV.y * (var_h-var_i));
	float var_3 = HSV.z * (1.0 - HSV.y * (1-(var_h-var_i)));
	if      (var_i == 0) { RGB = float3(HSV.z, var_3, var_1); }
	else if (var_i == 1) { RGB = float3(temp2, HSV.z, var_1); }
	else if (var_i == 2) { RGB = float3(var_1, HSV.z, var_3); }
	else if (var_i == 3) { RGB = float3(var_1, temp2, HSV.z); }
	else if (var_i == 4) { RGB = float3(var_3, var_1, HSV.z); }
	else                 { RGB = float3(HSV.z, var_1, temp2); }

	return (RGB);
}

#endif	// #!ifdef COCO_USE_COLOR_HSV



// DisColor --------------------------------------

float3 replace_hue_by_hsl (float3 col, float hue)
{
	float3 col_hsl = rgb_to_hsl (col);
	col_hsl.x = hue;
	return hsl_to_rgb (col_hsl);
}

float3 replace_hue_by_hsl_fix (float3 col, float hue, float saturMin, float saturRatio, float saturAdd, float _lightMax, float _lightRatiio, float _lightAdd)
{
	float3 col_hsl = rgb_to_hsl (col);

	if(col_hsl.y < saturMin)
		col_hsl.y = col_hsl.y * saturRatio + saturAdd;

	if(col_hsl.z > _lightMax)
		col_hsl.z = col_hsl.z * _lightRatiio + _lightAdd;

	col_hsl.x = hue;
	return hsl_to_rgb (col_hsl);
}

float3 blend_hsl_to_rgb (float3 col, float h, float s, float l)
{
	// S
	float3 hsl = rgb_to_hsl (col);
	if (s >= 0) {
		if (s >= 1)
			s = 0.99999;
		float alpha;
		if (s + hsl.y >= 1 && hsl.y > 0)
			alpha = hsl.y;
		else
			alpha = 1 - s;
		alpha = 1 / alpha - 1;
		col = col + (col - hsl.z) * alpha;
	} else {
		col = hsl.z + (col - hsl.z) * (1 + s);
	}
	
	// L
	if (l >= 0) {
		col = l + col * (1 - l);
	} else {
		col *= (1 + l);
	}
	
	// H
	hsl = rgb_to_hsl (col);
	hsl.x +=h;
	
	return hsl_to_rgb (hsl);
}

#endif	// #ifndef COCOCG_COLOR

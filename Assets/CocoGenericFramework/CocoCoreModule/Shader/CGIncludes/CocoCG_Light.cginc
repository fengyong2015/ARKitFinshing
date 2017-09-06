#ifndef COCOCG_LIGHT
#define COCOCG_LIGHT


// properties -------------------------------------
// wrap
half _WrapPower;
half _LightPower;
// rim
fixed4 _RimColor;
half _RimPower;


// lighting functions -------------------------------------
fixed4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
	half NdotL = dot (s.Normal, lightDir);
	half diff = NdotL * (1 - _WrapPower) + _WrapPower;
	fixed4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten * _LightPower);
	c.a = s.Alpha;
	return c;
}


// effect functions -------------------------------------
half3 rim (half3 viewDir, half3 normalDir)
{
	half rim = 1.0 - saturate(dot (normalize(viewDir), normalDir));
	return _RimColor.rgb * pow (rim, _RimPower);
}

#endif

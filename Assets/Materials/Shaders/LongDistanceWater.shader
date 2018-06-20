Shader "Dvornik/Long Distance Water" {
Properties {
	_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_Refraction ("Refraction", Range (0.00, 1.0)) = 0.02	
	_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)	
	_ReflectionTex ("_ReflectionTex", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

SubShader 
{	
	
	Tags { "RenderType"="Opaque" }
	
CGPROGRAM

#pragma surface surf BlinnPhong

sampler2D _BumpMap;
sampler2D _ReflectionTex;

float4 _ReflectColor;
float _Shininess;
float _Refraction;
float _BumpReflectionStr;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap; 
	float4 screenPos;
	float3 viewDir;
	INTERNAL_DATA
};

void surf (Input IN, inout SurfaceOutput o) 
{	
	//Specular stuff
	o.Gloss = _SpecColor.a;
	o.Specular = _Shininess;
	
	//Normal stuff
	o.Normal = UnpackNormal(tex2D(_BumpMap, 2.0 * IN.uv_BumpMap + 0.01 * _Time.y ));
	o.Normal += UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - 0.01 * _Time.y));
	o.Normal *= 0.5;

	float2 offset = o.Normal * _Refraction;
	IN.screenPos.xy = offset * IN.screenPos.z + IN.screenPos.xy;	
		
	half4 reflcol = tex2Dproj(_ReflectionTex, IN.screenPos);
	reflcol = reflcol * _ReflectColor;
	
	half4 resCol = reflcol;	
	
	o.Emission = resCol;
	o.Albedo = o.Emission;

}
ENDCG
}
	
FallBack "Reflective/Bumped Diffuse"
}

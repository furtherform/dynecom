Shader "Janne/Gradient" {
Properties {
	_Color ("Top Color", Color) = (1,1,1,1)
	_Color2 ("Bottom Color", Color) = (1,1,1,1)
	_Threshold ("Threshold", Range(0,1)) = 0.5
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

sampler2D _MainTex;
fixed4 _Color;
fixed4 _Color2;
half _Threshold;

struct Input {
	float2 uv_MainTex;
	float4 screenPos;
};

void surf (Input IN, inout SurfaceOutputStandard o) {
	float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * lerp(_Color, _Color2, screenUV.y + _Threshold);
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "Legacy Shaders/VertexLit"
}

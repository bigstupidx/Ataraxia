Shader "Mobile/Vampires/Unlit Transparent Grayscale (slow)" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	   	_Brightness ("Brigtness", Range (0, 1)) = 0.5
	   	_MixColor ("MixColor", Color) = (0.3, 0.59, 0.11)
	}
	
	SubShader 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "LightMode"="Vertex" }

		CGPROGRAM
		#pragma surface surf Unlit alpha

		sampler2D _MainTex;
		float _Brightness;
		float3 _MixColor;

		half4 LightingUnlit (SurfaceOutput s, half3 lightDir, half atten) 
		{
			half4 c;
          	c.rgb = s.Albedo * _Brightness;
          	c.a = s.Alpha;
        	return c;
        }

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = dot(c.rgb, _MixColor);
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Mobile/Vampires/UnlitTransparent"
}
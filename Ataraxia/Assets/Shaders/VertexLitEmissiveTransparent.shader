Shader "Mobile/Vampires/VertexLitEmissiveTransparent" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Emissive ("Emissive", Range (0, 1)) = 0
     }
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100
		ZWrite Off
		Alphatest Greater 0
		Blend SrcAlpha OneMinusSrcAlpha 
			
		Pass {
			Tags { "LightMode" = "Vertex" }
			
			Material {
				Diffuse (1,1,1,1)
				Ambient (1,1,1,1)
				Emission ([_Emissive], [_Emissive], [_Emissive], [_Emissive])
			} 
			Lighting On

			SetTexture [_MainTex] {
				Combine primary * texture DOUBLE, primary * texture
			}	
		}
	} 
	
	FallBack "Mobile/VertexLit"
}

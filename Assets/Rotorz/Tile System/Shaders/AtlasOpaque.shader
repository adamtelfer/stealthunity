Shader "Rotorz/Atlas/Opaque" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Lighting Off
		Fog { Mode Off }
		
		Pass {
			SetTexture[_MainTex] {}
		}
	}
	
	FallBack "Diffuse"
}

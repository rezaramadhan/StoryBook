Shader "Custom/NewSurfaceShader" {
	Properties {
		_Scale ("Scale", float) = 1
		_Speed ("Speed", float) = 1
		_Frequency ("Frequency", float) = 1
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		float _Scale, _Speed, _Frequency;
		float _Wave1, _Wave2, _Wave3, _Wave4;
		float _OffsetX1, _OffsetX2, _OffsetX3, _OffsetX4;
		float _OffsetZ1, _OffsetZ2, _OffsetZ3, _OffsetZ4;
		float _Distance1, _Distance2, _Distance3, _Distance4;
		float _xImpact1, _xImpact2, _xImpact3, _xImpact4;
		float _zImpact1, _zImpact2, _zImpact3, _zImpact4;


		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void vert (inout appdata_full v) {
			half offsetvert = (v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z);

			half offsetvert2 = v.vertex.x + v.vertex.z; //diagonal waves
			//half offsetvert2 = v.vertex.x; //horizontal waves
			
			half value0 = _Scale * sin(_Time.w * _Speed * _Frequency + offsetvert2 );
			
			half value1 = _Scale*sin(_Time.w * _Speed * _Frequency + offsetvert + v.vertex.x*_OffsetX1 + v.vertex.z*_OffsetZ1);
			half value2 = _Scale*sin(_Time.w * _Speed * _Frequency + offsetvert + v.vertex.x*_OffsetX2 + v.vertex.z*_OffsetZ2);
			half value3 = _Scale*sin(_Time.w * _Speed * _Frequency + offsetvert + v.vertex.x*_OffsetX3 + v.vertex.z*_OffsetZ3);
			half value4 = _Scale*sin(_Time.w * _Speed * _Frequency + offsetvert + v.vertex.x*_OffsetX4 + v.vertex.z*_OffsetZ4);

			float3 worldPos = mul(_Object2World, v.vertex).xyz;

			v.vertex.y += value0; //remove for no waves

			if (sqrt(pow(worldPos.x - _xImpact1, 2) + pow(worldPos.z - _zImpact1, 2)) < _Distance1) {
				v.vertex.y += value1 * _Wave1;
			}
			if (sqrt(pow(worldPos.x - _xImpact2, 2) + pow(worldPos.z - _zImpact2, 2)) < _Distance2) {
				v.vertex.y += value2 * _Wave2;
			}
			if (sqrt(pow(worldPos.x - _xImpact3, 2) + pow(worldPos.z - _zImpact3, 2)) < _Distance3) {
				v.vertex.y += value3 * _Wave3;
			}
			if (sqrt(pow(worldPos.x - _xImpact4, 2) + pow(worldPos.z - _zImpact4, 2)) < _Distance4) {
				v.vertex.y += value4 * _Wave4;
			}
		}


		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}

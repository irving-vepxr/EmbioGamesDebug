Shader "EmbrioGames/VenasAnimation"
{
	Properties
	{
		_MainTex("Base",2D) = "white"{}
		_Speed("Wave", Range(0.1, 80)) = 5
		_Frequency("Frecuencia", Range(0,5)) = 2
		_Amplitude("Amplitud", range(-1,1)) = 1
	}

		SubShader{
				CGPROGRAM
				#pragma surface surf Lambert vertex:vert

				sampler2D _MainTex;
		float _Speed;
		float _Amplitude;
		float _Frequency;
		struct Input {
			float2 uv_MainTex;
			float3 vertColor;
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float time = _Time * _Speed;
			float wave = sin(time + v.vertex.x * _Frequency) * _Amplitude;
			v.vertex.xyz = float3(v.vertex.x + wave, v.vertex.y , v.vertex.z + wave);
			v.texcoord.xy = float2(v.texcoord.x + wave, v.texcoord.y + wave);
			v.normal = normalize(float3(v.normal.x + wave, v.normal.y, v.normal.z + wave));
			o.vertColor = float3(1, 1, 1);
		}

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
		}
	Fallback "Diffuse"
}
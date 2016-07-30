Shader "Diplomado/GrayScale"
{
	Properties
	{
		_MainTex ("Base", 2D) = "white" {}
		_LuminosityAmount("GrayScale", Range(0,1)) = 1.0
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed _LuminosityAmount;
			fixed4 frag(v2f_img i) : COLOR
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				float luminosity = 0.299 * renderTex.r +
								   0.587 * renderTex.g +
								   0.114 * renderTex.b;
				fixed4 finalColor = lerp(renderTex, luminosity, _LuminosityAmount);
				return finalColor;
			} 
			ENDCG
		}
	}

	FallBack "Diffuse"
}

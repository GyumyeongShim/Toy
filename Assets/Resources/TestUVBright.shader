Shader "인스펙터에 경로추가/내가 만든 쉐이더2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Brightness("밝기 조절", Range(-1,1)) = 0
    }
    SubShader
    {
		Tags { "RenderType" = "Opaque" }

        CGPROGRAM
		#pragma surface surf Standard

        sampler2D _MainTex;
		
		struct Input
		{
			float2 uv_MainTex;
		};

		float _Brightness;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			//o.Albedo = 0.299*c.r + 0.587*c.g + 0.114*c.b; //흑백사진효과
			o.Albedo = c.rgb + _Brightness; //단순 밝기 변화
		}
		ENDCG
    }
	FallBack "Diffuse"
}

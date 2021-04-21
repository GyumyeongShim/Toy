Shader "인스펙터에 경로추가/내가 만든 쉐이더1"
{
	//여기는 에디터로 수정할 수 있는 부분을 의미하는듯함
    Properties
    {
		//_변수 ("텍스트", 자료형) = 초기값
        _Color ("Color", Color) = (1,1,1,1) 
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_nokorean("범위 없음",float) = 0.5
		_justEngPlz("범위 지정",Range(0,1)) = 0

		fR("Red", Range(0,1)) = 1.0
		fG("Green", Range(0,1)) = 1.0
		fB("Blue", Range(0,1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM //여기서부터 쉐이더 코드가 시작되는 부분이라함 CG언어(엔비디아용)
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

		float fR;
		float fG;
		float fB;

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_INSTANCING_BUFFER_END(Props)
		//SurfaceOutputStandard 구조체로 구현되어있음
		//내부에 알베도,노말,이미션,메타릭,스무스니스,오클루전,알파

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;

            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;
			o.Emission = float3(fR, fG, fB);
        }
        ENDCG
    }
    FallBack "Diffuse"
}

Shader "Unlit/MultiMonitor"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Angle("Angle", Range(-360, 360)) = 0
        _OffsetPosition("Offset Position", Vector) = (0,0,0,0)
        _Scale("Scale", Vector) = (1,1,1,1)

        _ChromaStrength("Chroma strength", Range(0.0, 0.1)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

#define rot(a) float2x2(cos(a), -sin(a), sin(a), cos(a))

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _ChromaStrength;
            float _Angle;
            float2 _OffsetPosition;
            float2 _Scale;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                uv = mul(uv, rot(radians(_Angle)));
                uv += _OffsetPosition;
                uv *= _Scale;

                float pix = 0.02;
                uv = floor(uv / pix) * pix;

                float2 chromaDir = float2(_ChromaStrength, 0.);
                fixed4 col = 1.0;//tex2D(_MainTex, uv);
                col.r = tex2D(_MainTex, uv + chromaDir).r;
                col.g = tex2D(_MainTex, uv).g;
                col.b = tex2D(_MainTex, uv - chromaDir).b;

                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}

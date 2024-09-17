Shader "Unlit/PostEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BlitTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
//                    uint2 pixelCoords = uint2(i.uv * _ScreenSize.xy);
            //float4 col = LOAD_TEXTURE2D_X_LOD(_BlitTexture, i.uv, 0).zxy;
                // sample the texture
                fixed4 col = tex2D(_BlitTexture, i.uv);
            col.xyz = col.xxx;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                col = float4(1., 0., 0., 1.);
                return col;
            }
            ENDCG
        }
    }
}

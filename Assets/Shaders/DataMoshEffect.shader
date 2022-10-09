Shader "CustomEffects/DataMoshEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        GrabPass
        {
            "_PR"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            sampler2D _MainTex;
            sampler2D _CameraMotionVectorsTexture;
            sampler2D _PR;
            int _Button;

            fixed4 frag (v2f i) : SV_Target
            {
                float4 mot = tex2D(_CameraMotionVectorsTexture, i.uv);
                //fixed4 col = tex2D(_MainTex, i.uv + mot.rg);

                //col += mot;
                
                #if UNITY_UV_STARTS_AT_TOP
                    float2 movUV = float2(  i.uv.x - mot.r,
                                            i.uv.y + mot.g);
                #else
                    float2 movUV = float2(  i.uv.x - mot.r,
                                            1 - i.uv.y - mot.g);
                #endif
                
                fixed4 current = tex2D(_MainTex, i.uv);
                fixed4 prev = tex2D(_PR, movUV);

                fixed4 col = lerp(current, prev, _Button);

                return col;
            }
            ENDCG
        }
    }
}

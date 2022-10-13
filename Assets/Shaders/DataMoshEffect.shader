Shader "CustomEffects/DataMoshEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }

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
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 uvgrab : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uvgrab = ComputeGrabScreenPos(o.vertex);
                o.uvgrab.y = 1 - o.uvgrab.y;
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _CameraMotionVectorsTexture;
            sampler2D _PR;
            int _Button;

            fixed4 frag (v2f i) : SV_TARGET
            {
                float4 mot;
                
                //fixed4 col = tex2D(_MainTex, i.uv + mot.rg);
                //col += mot;
                
                #if UNITY_UV_STARTS_AT_TOP
                    //i.uvgrab.y = 1 - i.uvgrab.y;
                    mot = tex2D(_CameraMotionVectorsTexture, i.uvgrab);
                    float2 movUV = float2(  i.uvgrab.x - mot.r,
                                            i.uvgrab.y + mot.g);
                #else
                    mot = tex2D(_CameraMotionVectorsTexture, i.uvgrab);
                    float2 movUV = float2(  i.uvgrab.x - mot.r,
                                            i.uvgrab.y - mot.g);
                #endif
                
                fixed4 current = tex2D(_MainTex, i.uvgrab);
                fixed4 prev = tex2D(_PR, movUV);

                fixed4 col = lerp(current, prev, 1);

                return col;
            }
            ENDCG
        }
    }
}

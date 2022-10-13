// adapted from https://www.shadertoy.com/view/Ms3XWH

Shader "CustomEffects/VHSEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Range ("Range", Range(0.0, 1.0)) = 0.05
        _BandFreq ("Banding Frequency", Range(0.0, 300.0)) = 3.0
        _BandIntens ("Banding Intensity", Range(0.0, 1)) = .0088
        _Offset ("Offset Distance", Range(0.0, 1.0)) = 0.02
        _ColorOffset ("Color Offset Distance", Range(0.0, 5)) = 0.2
        _Period ("Periodiciy", Range(0.0, 1.0)) = 0.24
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            // float4 _Time; // no need to redefine it
            float _Range;
            float _BandFreq;
            float _BandIntens;
            float _Offset;
            float _ColorOffset;
            float _Period;

            float randomGen(float2 pos)
            {
                return frac(sin(dot(pos.xy, float2(12.9898, 78.233))) * 43758.5453);
            }

            fixed scanLines(fixed pos, fixed y, fixed offset)
            {
                fixed edge0 = pos - _Range;
                fixed edge1 = pos + _Range;

                return ( smoothstep(edge0, pos, y) * _Offset) - (smoothstep(edge1, pos, y) * _Offset); 
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 newUV = i.uv;

                for (float i = 0.0; i < 0.71; i += 0.1313)
                {
                    float distort = fmod(_Time.y * i, 1.7);
                    float offset = sin(1.0 - tan(_Time.y * _Period * i));
                    offset *= _Offset;
                    newUV.x += scanLines(distort, newUV.y, offset);
                }

                fixed4 col = tex2D(_MainTex, newUV);

                return col;
            }
            ENDCG
        }
    }
}

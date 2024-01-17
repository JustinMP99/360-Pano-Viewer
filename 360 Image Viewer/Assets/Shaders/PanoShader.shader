Shader "Unlit/PanoShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color("Main Color", Color) = (1,1,1,0.5)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Front  //Have the inside of the sphere be rendered
       

       
        CGPROGRAM
            #pragma surface surf SimpleLambert 
            half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten)
            {
                half4 c;
              
                c.rgb = s.Albedo;
         
                return c;
            }
              

               

            sampler2D _MainTex;
            struct Input
            {
                float2 uv_MainTex;
                float4 myColor : COLOR;
            };


            fixed3 _Color;
            void surf(Input IN, inout SurfaceOutput o)
            {
                IN.uv_MainTex.x = 1 - IN.uv_MainTex.x;
                fixed3 result = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = result.rgb;
                o.Alpha = 1;
            }

            // struct appdata
            // {
            //     float4 vertex : POSITION;
            //     float2 uv : TEXCOORD0;
            // };

            // struct v2f
            // {
            //     float2 uv : TEXCOORD0;
            //     UNITY_FOG_COORDS(1)
            //     float4 vertex : SV_POSITION;
            // };

            // sampler2D _MainTex;
            // float4 _MainTex_ST;

            // v2f vert (appdata v)
            // {
            //     v2f o;
            //     o.vertex = UnityObjectToClipPos(v.vertex);
            //     o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            //     UNITY_TRANSFER_FOG(o,o.vertex);
            //     return o;
            // }

            // fixed4 frag (v2f i) : SV_Target
            // {
            //     // sample the texture
            //     fixed4 col = tex2D(_MainTex, i.uv);
            //     // apply fog
            //     UNITY_APPLY_FOG(i.fogCoord, col);
            //     return col;
            // }
            ENDCG

        //FallBack "Diffuse"
    }
}

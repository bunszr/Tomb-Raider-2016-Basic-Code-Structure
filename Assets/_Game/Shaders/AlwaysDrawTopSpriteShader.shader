// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Sprites/AlwaysDrawTopSpriteShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest Always
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment SpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"
        ENDCG
        }
    }
}











// Shader "Unlit/NewUnlitShader"
// {
//     Properties
//     {
//         _MainTex ("Texture", 2D) = "white" {}
//         _Color ("Color", Color) = (0.5,0.5,0.5,0.5)
//     }
//     SubShader
//     {
//         Tags { "RenderType"="Opaque" }
//         ZTest Always
//         LOD 100

//         Pass
//         {
//             CGPROGRAM
//             #pragma vertex vert
//             #pragma fragment frag
//             // make fog work
//             #pragma multi_compile_fog

//             #include "UnityCG.cginc"

//             struct appdata
//             {
//                 float4 vertex : POSITION;
//                 float2 uv : TEXCOORD0;
//             };

//             struct v2f
//             {
//                 float2 uv : TEXCOORD0;
//                 UNITY_FOG_COORDS(1)
//                 float4 vertex : SV_POSITION;
//             };

//             sampler2D _MainTex;
//             float4 _MainTex_ST;
//             float _Color;

//             v2f vert (appdata v)
//             {
//                 v2f o;
//                 o.vertex = UnityObjectToClipPos(v.vertex);
//                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
//                 UNITY_TRANSFER_FOG(o,o.vertex);
//                 return o;
//             }

//             fixed4 frag (v2f i) : SV_Target
//             {
//                 // sample the texture
//                 // fixed4 col = tex2D(_MainTex, i.uv) * _Color;
//                 fixed4 col = _Color;
//                 // apply fog
//                 // UNITY_APPLY_FOG(i.fogCoord, col);
//                 return col;
//             }
//             ENDCG
//         }
//     }
// }

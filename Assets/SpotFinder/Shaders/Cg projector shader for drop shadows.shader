﻿Shader "Cg projector shader for drop shadows" {
   Properties {
      _ShadowTex ("Projected Image", 2D) = "white" {}
   }
   SubShader {
      Pass {      
          Blend Zero OneMinusSrcAlpha // attenuate color in framebuffer 
            // by 1 minus alpha of _ShadowTex 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         // User-specified properties
         uniform sampler2D _ShadowTex; 
 
         // Projector-specific uniforms
         uniform float4x4 _Projector; // transformation matrix 
            // from object space to projector space 
 
          struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 posProj : TEXCOORD0;
               // position in projector space
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            output.posProj = mul(_Projector, input.vertex);
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
 
         float4 frag(vertexOutput input) : COLOR
         {
            if (input.posProj.w > 0.0) // in front of projector?
            {
               return tex2D(_ShadowTex , 
                  float2(input.posProj) / input.posProj.w); 
               // alternatively: 
//               return = tex2Dproj(  
//                   _ShadowTex, float3(input.posProj));
            }
            else // behind projector
            {
               return float4(0.0);
            }
         }
 
         ENDCG
      }
   }  
   // The definition of a fallback shader should be commented out 
   // during development:
   // Fallback "Projector/Light"
}
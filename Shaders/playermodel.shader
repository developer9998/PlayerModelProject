// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5262,x:32719,y:32712,varname:node_5262,prsc:2|emission-5058-OUT,clip-9383-OUT;n:type:ShaderForge.SFN_Color,id:4739,x:31443,y:32631,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1638,x:31444,y:32437,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_1638,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7059-OUT;n:type:ShaderForge.SFN_Fresnel,id:2612,x:31734,y:33035,varname:node_2612,prsc:2|EXP-2620-OUT;n:type:ShaderForge.SFN_Slider,id:7000,x:31241,y:33004,ptovrint:False,ptlb:fresnel amount,ptin:_fresnelamount,varname:node_7000,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.366337,max:10;n:type:ShaderForge.SFN_Color,id:7371,x:31909,y:32889,ptovrint:False,ptlb:fresnelcolor,ptin:_fresnelcolor,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6745283,c2:1,c3:0.9772592,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:9681,x:32352,y:32810,ptovrint:False,ptlb:fresnel,ptin:_fresnel,varname:node_9681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-7203-OUT,B-9960-OUT;n:type:ShaderForge.SFN_Clamp01,id:5058,x:32531,y:32810,varname:node_5058,prsc:2|IN-9681-OUT;n:type:ShaderForge.SFN_Lerp,id:9960,x:32117,y:32829,varname:node_9960,prsc:2|A-7203-OUT,B-7371-RGB,T-957-OUT;n:type:ShaderForge.SFN_Multiply,id:957,x:31911,y:33036,varname:node_957,prsc:2|A-2612-OUT,B-1750-OUT;n:type:ShaderForge.SFN_Depth,id:7257,x:32006,y:33248,varname:node_7257,prsc:2;n:type:ShaderForge.SFN_Add,id:60,x:32186,y:33248,varname:node_60,prsc:2|A-7257-OUT,B-5767-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:7362,x:32362,y:33198,ptovrint:False,ptlb:clip active,ptin:_clipactive,varname:node_7362,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7061-OUT,B-60-OUT;n:type:ShaderForge.SFN_Vector1,id:7061,x:32187,y:33189,varname:node_7061,prsc:2,v1:100;n:type:ShaderForge.SFN_Tex2d,id:3333,x:31443,y:32806,ptovrint:False,ptlb:stincle_texture,ptin:_stincle_texture,varname:_texture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:255,x:31706,y:32831,varname:node_255,prsc:2|A-1638-RGB,B-4739-RGB,T-3333-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:7203,x:31908,y:32736,ptovrint:False,ptlb:stincle_active,ptin:_stincle_active,varname:_clipactive_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6381-OUT,B-255-OUT;n:type:ShaderForge.SFN_Multiply,id:6381,x:31703,y:32706,varname:node_6381,prsc:2|A-1638-RGB,B-4739-RGB;n:type:ShaderForge.SFN_Slider,id:1750,x:31582,y:33186,ptovrint:False,ptlb:fresnel_opacity,ptin:_fresnel_opacity,varname:_fresnelstrength_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_RemapRange,id:2620,x:31579,y:33001,varname:node_2620,prsc:2,frmn:0,frmx:10,tomn:10,tomx:0|IN-7000-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:7059,x:31232,y:32468,ptovrint:False,ptlb:UV_Map,ptin:_UV_Map,varname:node_7059,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3888-UVOUT,B-1468-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3888,x:30945,y:32422,varname:node_3888,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:1468,x:30956,y:32564,varname:node_1468,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Slider,id:6413,x:31659,y:33416,ptovrint:False,ptlb:Opacity Clip,ptin:_OpacityClip,varname:node_6413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_FaceSign,id:9090,x:32190,y:33048,varname:node_9090,prsc:2,fstp:0;n:type:ShaderForge.SFN_Multiply,id:9383,x:32550,y:32993,varname:node_9383,prsc:2|A-9277-OUT,B-7362-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9277,x:32356,y:32994,ptovrint:False,ptlb:Backface_Culling,ptin:_Backface_Culling,varname:node_9277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-49-OUT,B-9090-VFACE;n:type:ShaderForge.SFN_Vector1,id:49,x:32189,y:32993,varname:node_49,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:5767,x:32035,y:33441,varname:node_5767,prsc:2,frmn:0,frmx:1,tomn:1,tomx:-1|IN-6413-OUT;proporder:1638-7203-3333-4739-7000-7371-9681-7362-1750-7059-6413-9277;pass:END;sub:END;*/

Shader "Custom/playermodel" {
    Properties {
        _texture ("texture", 2D) = "white" {}
        [MaterialToggle] _stincle_active ("stincle_active", Float ) = 0
        _stincle_texture ("stincle_texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _fresnelamount ("fresnel amount", Range(0, 10)) = 3.366337
        _fresnelcolor ("fresnelcolor", Color) = (0.6745283,1,0.9772592,1)
        [MaterialToggle] _fresnel ("fresnel", Float ) = 0.6745283
        [MaterialToggle] _clipactive ("clip active", Float ) = 100
        _fresnel_opacity ("fresnel_opacity", Range(0, 1)) = 0.5
        [MaterialToggle] _UV_Map ("UV_Map", Float ) = 0
        _OpacityClip ("Opacity Clip", Range(0, 1)) = 0
        [MaterialToggle] _Backface_Culling ("Backface_Culling", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform sampler2D _stincle_texture; uniform float4 _stincle_texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _fresnelamount)
                UNITY_DEFINE_INSTANCED_PROP( float4, _fresnelcolor)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _fresnel)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _clipactive)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _stincle_active)
                UNITY_DEFINE_INSTANCED_PROP( float, _fresnel_opacity)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _UV_Map)
                UNITY_DEFINE_INSTANCED_PROP( float, _OpacityClip)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _Backface_Culling)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 projPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float _Backface_Culling_var = lerp( 1.0, isFrontFace, UNITY_ACCESS_INSTANCED_PROP( Props, _Backface_Culling ) );
                float _OpacityClip_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OpacityClip );
                float _clipactive_var = lerp( 100.0, (partZ+(_OpacityClip_var*-2.0+1.0)), UNITY_ACCESS_INSTANCED_PROP( Props, _clipactive ) );
                clip((_Backface_Culling_var*_clipactive_var) - 0.5);
////// Lighting:
////// Emissive:
                float2 _UV_Map_var = lerp( i.uv0, i.uv1, UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Map ) );
                float4 _texture_var = tex2D(_texture,TRANSFORM_TEX(_UV_Map_var, _texture));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float4 _stincle_texture_var = tex2D(_stincle_texture,TRANSFORM_TEX(i.uv0, _stincle_texture));
                float3 _stincle_active_var = lerp( (_texture_var.rgb*_Color_var.rgb), lerp(_texture_var.rgb,_Color_var.rgb,_stincle_texture_var.rgb), UNITY_ACCESS_INSTANCED_PROP( Props, _stincle_active ) );
                float4 _fresnelcolor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fresnelcolor );
                float _fresnelamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fresnelamount );
                float _fresnel_opacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fresnel_opacity );
                float3 _fresnel_var = lerp( _stincle_active_var, lerp(_stincle_active_var,_fresnelcolor_var.rgb,(pow(1.0-max(0,dot(normalDirection, viewDirection)),(_fresnelamount_var*-1.0+10.0))*_fresnel_opacity_var)), UNITY_ACCESS_INSTANCED_PROP( Props, _fresnel ) );
                float3 emissive = saturate(_fresnel_var);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( fixed, _clipactive)
                UNITY_DEFINE_INSTANCED_PROP( float, _OpacityClip)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _Backface_Culling)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD1;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float _Backface_Culling_var = lerp( 1.0, isFrontFace, UNITY_ACCESS_INSTANCED_PROP( Props, _Backface_Culling ) );
                float _OpacityClip_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OpacityClip );
                float _clipactive_var = lerp( 100.0, (partZ+(_OpacityClip_var*-2.0+1.0)), UNITY_ACCESS_INSTANCED_PROP( Props, _clipactive ) );
                clip((_Backface_Culling_var*_clipactive_var) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

Shader "Shaders/Healthbar Shader" 
{
	Properties 
	{
    	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    	_HealthPercentage("Health Percentage", float ) = 1.0
    	_Inverter("Inverter", float ) = 1.0
	}
 
	SubShader 
	{
   		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    	LOD 200
 
		CGPROGRAM
		#pragma surface surf Lambert alpha
 
		uniform sampler2D _MainTex;
		uniform float _HealthPercentage;
		uniform float _Inverter;
 
		struct Input 
		{
    		float2 uv_MainTex;
		};
 
		void surf (Input IN, inout SurfaceOutput o) 
		{
    		fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
    		
    		// Draw what health the player has
    		if( col.a != 0 && ( _Inverter * IN.uv_MainTex.x ) <= _HealthPercentage )
    		{
    			o.Albedo = col.rgb;
    			o.Alpha = col.a;
    		}
    		// Draw what health the player has lost
    		else if( col.a != 0 && IN.uv_MainTex.x > _HealthPercentage )
    		{
    			col = float4( 1.0f, 0.0f, 0.0f, col.a );
    			o.Albedo = col.rgb;
    			o.Alpha = col.a;
    		}
		}
		ENDCG
	}
 
	Fallback "Transparent/Diffuse"
}
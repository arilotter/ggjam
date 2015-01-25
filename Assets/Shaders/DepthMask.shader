Shader "DepthMask" {
	SubShader {
		ColorMask 0 // Masks the object with no rendering to all colour channels 
		Pass {} // Render the object, which in this case means disabling 
	}
}
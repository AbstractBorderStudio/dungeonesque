shader_type canvas_item;

uniform vec2 range = vec2(0.0);
uniform float size = 1.0;
uniform vec2 tex_scale = vec2(1.0);

void fragment() {
	// expand button from one shape to all screen
	vec2 uv = ((UV / TEXTURE_PIXEL_SIZE * 2.0 - 1.0) * tex_scale);
	
	
	
	vec2 normFrag = FRAGCOORD.xy / SCREEN_PIXEL_SIZE;
	
	float o = length(uv - range);
	if (o < size * tex_scale.x && o < size * tex_scale.y)
	{
		COLOR = vec4(1.0);
	}
	else 
	{
		COLOR = vec4(0.0);
	}
}

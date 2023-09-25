shader_type canvas_item;

uniform sampler2D texture;
uniform vec4 _col : source_color;

void fragment() {
	vec4 tex = texture(texture, UV);
	COLOR = tex * _col;
}

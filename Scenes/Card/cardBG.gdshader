shader_type canvas_item;

uniform vec4 _col : source_color = vec4(0.0, 0.0, 0.0, 1.0);

void fragment() {
	COLOR = _col;
}

namespace Entity.DTO;

[GraphQLName("ThemeInput")]
public class ThemeDto
{
    public int ColorR { get; set; }
    public int ColorG { get; set; }
    public int ColorB { get; set; }
    public string Name { get; set; }
}
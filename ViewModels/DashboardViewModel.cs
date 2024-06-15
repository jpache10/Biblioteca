
public class DashboardViewModel
{

    
    public int TotalEmpledos { get; set; }
    public int TotalUsuarios { get; set; }
    public List<DashBoardCard> Cards {get; set; }

}

public record DashBoardCard (
    string Title,
    string Description,
    Dictionary<string, int> estadisticas
);
//     public required string Title { get; init; }
//     public string Description { get; init; }
//     public int? CantidadRegistro { get; init; }
//     public int? CantidadRegistro { get; init; }
// }
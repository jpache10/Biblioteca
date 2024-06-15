
public class DashboardViewModel
{

    public DashboardViewModel(string descripcion = "Bienvenido a la biblioteca de unapec")
    {
        Descripcion = descripcion;
        Cards = new List<DashBoardCard>();
    }

    public string Descripcion { get; set; }
    public List<DashBoardCard> Cards { get; set; }

}

public class DashBoardCard
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Dictionary<string, int> estadistica { get; set; }
}

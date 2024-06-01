
public class ColumnConfig<T>
{
    public string Header { get; set; }
    public Func<T, object> ValueSelector { get; set; }
    public string CssClass { get; set; }
    public Func<T, object> HtmlContent { get; set; }
}

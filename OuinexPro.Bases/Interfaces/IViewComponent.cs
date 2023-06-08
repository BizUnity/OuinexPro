namespace OuinexPro.Bases.Interfaces;

public interface IViewComponent
{
    string DisplayName { get; }

    object? Content { get; set; }
}
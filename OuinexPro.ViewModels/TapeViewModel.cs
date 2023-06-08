using System.Collections.ObjectModel;
using ReactiveUI;

namespace OuinexPro.ViewModels;

public class TapeViewModel : ReactiveObject
{
    public ObservableCollection<string> Items { get; } = new()
    {
        "Ouinex announce it's launch",
        "XRP Price Prediction Following Huge $2 Billion Capital Surge - Can XRP Reach $10 in 2023?",
        "LUS Senators Express Concerns over El Salvador's Bitcoin Adoption – What's Going On?",
        "Lorem ipsum dosimeter"
    };
}
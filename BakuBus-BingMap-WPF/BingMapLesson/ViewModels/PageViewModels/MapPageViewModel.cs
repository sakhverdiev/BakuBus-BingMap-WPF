using BingMapLesson.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace BingMapLesson.ViewModels.PageViewModels;

public class MapPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<AvtoBus> buses;
    public ObservableCollection<AvtoBus> Buses { get => buses; set { buses = value; OnPropertyChanged(); } }
    public MapPageViewModel()
    {
        var folder = new DirectoryInfo("../../../DataBase");

        var fullPath = folder + "/bakubusApi.json";

        var jsonText = File.ReadAllText(fullPath);

        var buses = JsonSerializer.Deserialize<BakuBus>(jsonText);


        Buses = new ObservableCollection<AvtoBus>(buses!.BUS);
        AllBuses.Buses = Buses;
    }


    // ------------------------------------------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyNmae = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNmae));
}

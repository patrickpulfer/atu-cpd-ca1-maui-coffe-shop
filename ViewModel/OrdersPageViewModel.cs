using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using Windows.Graphics.Printing3D;

namespace CoffeeShop.ViewModel
{
    public partial class OrdersPageViewModel : ObservableObject
    {

        [ObservableProperty]
        string jsonFileContent;

        private static string ReadJsonFile()
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullpath = Path.Combine(path, "Orders.json");
            var text = File.ReadAllText(fullpath);

            System.Diagnostics.Debug.Write("Order Json File: ");
            System.Diagnostics.Debug.WriteLine(text);

            
            using JsonDocument document = JsonDocument.Parse(text);
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions() { Indented = true });
            document.WriteTo(writer);
            writer.Flush();
            

            //return JsonConvert.DeserializeObject<string[]>(text);


            return Encoding.UTF8.GetString(stream.ToArray());
        }



        private void Load()
        {
            JsonFileContent = ReadJsonFile();
        }

        public OrdersPageViewModel()
        {
            Load();
        }

    }
}
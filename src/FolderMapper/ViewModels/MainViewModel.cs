using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FolderMapper.ViewModels
{
    public sealed class MainViewModel
    {
        public string Title { get; } = "CodeDek's Folder Mapper";
        public double MinHeight { get; } = 400.0;
        public double MinWidth { get; } = 600.0;
        public string Status { get; set; } = "Made by CodeDek";
        public Brush StatusColor { get; set; } = Brushes.Red;
        public Brush BackgroundColor { get; set; } = Brushes.Gray;
        public static IList<string> DriveLetters => new[] { "None", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public MapViewModel MapViewModel { get; } = new MapViewModel();
        public UnMapViewModel UnMapViewModel { get; } = new UnMapViewModel();
    }
}

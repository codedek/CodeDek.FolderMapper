using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using CodeDek.Lib.FortuneCookie;
using CodeDek.Lib.Mvvm;

namespace FolderMapper.ViewModels
{
    public sealed class MainViewModel : ObservableObject
    {
        private string _status;
        private string _passage;
        private string _passageUrl;
        private Brush _statusColor = Brushes.Black;
        private Brush _backgroundColor = Brushes.LightGray;

        public MainViewModel()
        {
            var (text, passage, url) = CookieGenerator.GenerateCookie(CookieType.Promises);
            Status = text;
            Passage = passage;
            PassageUrl = url;
            MapViewModel = new MapViewModel(this);
            UnMapViewModel = new UnMapViewModel(this);
        }

        public static IList<string> DriveLetters => new[] { "None", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public string Title { get; } = "CodeDek's Folder Mapper";
        public double MinHeight { get; } = 400.0;
        public double MinWidth { get; } = 600.0;
        public MapViewModel MapViewModel { get; }
        public UnMapViewModel UnMapViewModel { get; }
        public AboutViewModel AboutViewModel { get; } = new AboutViewModel();

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public string Passage
        {
            get => _passage;
            set => Set(ref _passage, value);
        }

        public string PassageUrl
        {
            get => _passageUrl;
            set => Set(ref _passageUrl, value);
        }

        public Brush StatusColor
        {
            get => _statusColor;
            set => Set(ref _statusColor, value);
        }

        public Brush BackgroundColor
        {
            get => _backgroundColor;
            set => Set(ref _backgroundColor, value);
        }

        public Cmd GoToUrlCmd => new Cmd(() => Process.Start(PassageUrl));
    }
}

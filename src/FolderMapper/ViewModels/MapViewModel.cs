using System;
using System.Windows;
using CodeDek.Lib;
using CodeDek.Lib.Mvvm;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderMapper.ViewModels
{
    public sealed class MapViewModel : ObservableObject
    {
        private string _selectedPath;
        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value)
                .Alert(nameof(SelectCmd))
                .Alert(nameof(MapCmd));
        }

        public string SelectedPath
        {
            get => _selectedPath;
            set => Set(ref _selectedPath, value)
                .Alert(nameof(MapCmd));
        }

        public Cmd SelectCmd => new Cmd(() =>
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = $"Select a folder to map drive {MainViewModel.DriveLetters[SelectedIndex]} to.";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.EnsureValidNames = true;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SelectedPath = dlg.FileName;
            }

        }, () => SelectedIndex > 0);

        public Cmd MapCmd => new Cmd(() =>
        {
            var letter = char.Parse(MainViewModel.DriveLetters[SelectedIndex]);
            var path = SelectedPath;

            if (!string.IsNullOrWhiteSpace(path) && letter != default)
            {
                var result = MessageBox.Show("Proceed with mapping?", "Confirmation 😕", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes && Storage.MapDriveToDirectory(letter, path))
                {
                    MessageBox.Show($"Drive {letter} was mapped to {path}.", "Success 😎", MessageBoxButton.OK, MessageBoxImage.Information);
                    SelectedIndex = 0;
                    SelectedPath = "";
                }
            }
        }, () => SelectedIndex > 0 && !string.IsNullOrWhiteSpace(SelectedPath));
    }
}

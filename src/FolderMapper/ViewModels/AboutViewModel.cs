using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using CodeDek.Lib.Mvvm;

namespace FolderMapper.ViewModels
{
    public class AboutViewModel
    {
        public byte[] AppIcon { get; set; } = File.ReadAllBytes(@"D:\.repo\_product\CodeDek.FolderMapper\art\ic_folder_mapper.ico");
        public string Website { get; set; } = "https://github.com/codedek/CodeDek.FolderMapper";
        public string UpdateUrl { get; set; }
        public string AppName => "Folder Mapper";
        public string AppVersion => $"v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion} beta";
        public string Copyright => "© 2019 CodeDek. All Rights Reserved";
        public string Developer => "Written by CodeDek";

        //public Cmd NavigateProjectUrlCmd => new Cmd(() => Process.Start(Website));
    }
}

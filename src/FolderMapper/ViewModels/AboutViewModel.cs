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
        public string Home { get; set; } = "https://github.com/codedek/CodeDek.FolderMapper";
        public string Download { get; set; } = "https://github.com/codedek/CodeDek.FolderMapper/releases";
        public string Issues { get; set; } = "https://github.com/codedek/CodeDek.FolderMapper/issues";
        public string License => "https://github.com/codedek/CodeDek.FolderSharer/blob/master/LICENSE";
        public string Changelog => "https://github.com/codedek/CodeDek.FolderSharer/blob/master/CHANGELOG.md";
        public string AppName => "Folder Mapper";
        public string AppVersion => $"v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}";
        public string Copyright => "© 2019 CodeDek. All Rights Reserved";
        public string Developer => "Written by CodeDek";

        public Cmd NavigateHomeUrlCmd => new Cmd(() => Process.Start(Home));
        public Cmd NavigateDownloadUrlCmd => new Cmd(() => Process.Start(Download));
        public Cmd NavigateIssuesUrlCmd => new Cmd(() => Process.Start(Issues));
        public Cmd NavigateLicenseUrlCmd => new Cmd(() => Process.Start(License));
        public Cmd NavigateChangelogUrlCmd => new Cmd(() => Process.Start(Changelog));
    }
}

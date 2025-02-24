using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BmsManager.Entity;
using BmsManager.View;
using CommonLib.Wpf;

namespace BmsManager
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowFileRegister { get; set; }

        public ICommand ShowTableManager { get; set; }

        public ICommand ShowDuplicateChecker { get; set; }

        public ICommand ShowDiffRegister { get; set; }

        public ICommand ShowExporter { get; set; }

        public ICommand DBReset { get; set; }

        public MainWindowViewModel()
        {
            ShowFileRegister = CreateCommand(() => new FolderRegisterer().Show());
            ShowTableManager = CreateCommand(() => new BmsTableManager().Show());
            ShowDuplicateChecker = CreateCommand(() => new DuplicateBmsChecker().Show());
            ShowDiffRegister = CreateCommand(() => new DiffRegisterer().Show());
            ShowExporter = CreateCommand(() => new Exporter().Show());

            DBReset = CreateCommand(DBResetAct);
        }

        public void DBResetAct()
        {
            var result = MessageBox.Show("データ量が多いと時間がかかります。処理を続けますか？",
                             "確認",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            using var con = new BmsManagerContext();

            con.Files.RemoveRange(con.Files);
            con.BmsFolders.RemoveRange(con.BmsFolders);
            con.RootDirectories.RemoveRange(con.RootDirectories);
            con.Tables.RemoveRange(con.Tables);
            con.Difficulties.RemoveRange(con.Difficulties);
            con.TableDatas.RemoveRange(con.TableDatas);

            con.SaveChanges();

            MessageBox.Show("完了");
        }
    }
}

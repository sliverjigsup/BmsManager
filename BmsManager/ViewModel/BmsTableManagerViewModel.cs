﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BmsManager.Entity;
using CommonLib.Wpf;
using Microsoft.EntityFrameworkCore;

namespace BmsManager.ViewModel
{
    class BmsTableManagerViewModel : ViewModelBase
    {
        public BmsTableTreeViewModel BmsTableTree { get; set; }
        public BmsTableDataListViewModel TableDataList { get; set; }

        public BmsTableManagerViewModel()
        {
            BmsTableTree = new BmsTableTreeViewModel();
            TableDataList = new BmsTableDataListViewModel();
            BmsTableTree.PropertyChanged += BmsTableTree_PropertyChanged;
        }

        private void BmsTableTree_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BmsTableTreeViewModel.SelectedTreeItem))
                TableDataList.Table = BmsTableTree.SelectedTreeItem;
        }
    }
}

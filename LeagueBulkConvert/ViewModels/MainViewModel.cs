﻿using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LeagueBulkConvert.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private bool allowConversion;
        public bool AllowConversion
        {
            get => allowConversion;
            set
            {
                allowConversion = value;
                OnPropertyChanged();
            }
        }

        private bool enableSkeletonCheckbox = true;
        public bool EnableSkeletonCheckbox
        {
            get => enableSkeletonCheckbox;
            set
            {
                enableSkeletonCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool includeAnimations;
        public bool IncludeAnimations
        {
            get => includeAnimations;
            set
            {
                includeAnimations = value;
                OnPropertyChanged();
                if (value)
                {
                    IncludeSkeletons = true;
                    EnableSkeletonCheckbox = false;
                    return;
                }
                EnableSkeletonCheckbox = true;
            }
        }

        public bool IncludeHiddenMeshes { get; set; }

        private bool includeSkeletons;
        public bool IncludeSkeletons
        {
            get => includeSkeletons;
            set
            {
                includeSkeletons = value;
                OnPropertyChanged();
            }
        }

        private Visibility loadingVisibility = Visibility.Hidden;
        public Visibility LoadingVisibility
        {
            get => loadingVisibility;
            set
            {
                loadingVisibility = value;
                OnPropertyChanged();
            }
        }

        private string leaguePath;
        public string LeaguePath
        {
            get => leaguePath;
            set
            {
                leaguePath = value;
                OnPropertyChanged();
                if (Directory.Exists(value) && Directory.Exists(OutPath))
                    AllowConversion = true;
                else
                    AllowConversion = false;
            }
        }

        private string outPath;
        public string OutPath
        {
            get => outPath;
            set
            {
                outPath = value;
                OnPropertyChanged();
                if (Directory.Exists(value) && Directory.Exists(OutPath))
                    AllowConversion = true;
                else
                    AllowConversion = false;
            }
        }

        public bool ShowErrors { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
﻿using CleverDock.Managers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CleverDock.Model
{
    public class DockSettings : INotifyPropertyChanged
    {
        public const string SETTINGS_VERSION = "0.3.0";

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public static DockSettings DefaultDockSettings = new DockSettings
        {
            IconSize = 48,
            IconPadding = 20,
            CollapseDuration = 0.2,
            DockHideDuration = 0.5,
            DockShowDuration = 0.3,
            DockHideDelay = 300,
            DockShowDelay = 50,
            AutoHide = true,
            SaveAutomatically = true,
            ReserveScreenSpace = false,
            Icons = new List<SerializableIconInfo>(),
            Theme = ThemeManager.DefaultTheme
        };

        public string Version = SETTINGS_VERSION;

        private double _collapseDuration;
        public double CollapseDuration
        {
            get { return _collapseDuration; }
            set { _collapseDuration = value; OnPropertyChanged(); }
        }

        private double _dockHideDuration;
        public double DockHideDuration
        {
            get { return _dockHideDuration; }
            set { _dockHideDuration = value; OnPropertyChanged(); }
        }
        private double _dockShowDuration;
        public double DockShowDuration
        {
            get { return _dockShowDuration; }
            set { _dockShowDuration = value; OnPropertyChanged(); }
        }
        private double _dockHideDelay;
        public double DockHideDelay
        {
            get { return _dockHideDelay; }
            set { _dockHideDelay = value; OnPropertyChanged(); }
        }
        private double _dockShowDelay;
        public double DockShowDelay
        {
            get { return _dockShowDelay; }
            set { _dockShowDelay = value; OnPropertyChanged(); }
        }

        private int _iconPadding;
        public int IconPadding
        {
            get { return _iconPadding; }
            set { _iconPadding = value; OnPropertyChanged(); }
        }

        private int _iconSize;
        public int IconSize
        {
            get { return _iconSize; }
            set { _iconSize = value; OnPropertyChanged(); }
        }

        private Theme _theme;
        public Theme Theme
        {
            get { return _theme; }
            set { _theme = value; OnPropertyChanged(); }
        }

        private List<SerializableIconInfo> _icons;
        public List<SerializableIconInfo> Icons
        {
            get { return _icons; }
            set { _icons = value; OnPropertyChanged(); }
        }

        private bool _saveAutomatically;
        public bool SaveAutomatically
        {
            get { return _saveAutomatically; }
            set { _saveAutomatically = value; OnPropertyChanged(); }
        }

        private bool _reserveScreenSpace;
        public bool ReserveScreenSpace
        {
            get { return _reserveScreenSpace; }
            set {  _reserveScreenSpace = value; OnPropertyChanged(); }
        }

        private bool _autoHide;
        public bool AutoHide
        {
            get { return _autoHide; }
            set { _autoHide = value; OnPropertyChanged(); }
        }

        public int OuterIconSize
        {
            get { return IconSize + IconPadding; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
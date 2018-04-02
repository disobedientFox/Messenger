using Messenger;
using Messenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Messenger
{

    class WindowViewModel : BaseViewModel
    {
        #region Private member

        private Window mWindow;

        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;

        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 500;

        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        public int ResizeBorder => Borderless ? 0 : 6;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize); 

        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public int OuterMarginSize
        {
            get => Borderless ? 0 : mOuterMarginSize;
            set => mOuterMarginSize = value;
        }

        public int WindowRadius
        {
            get => Borderless ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public int TitleHeight { get; set; } = 30;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);


        public string AppTitle { get; set; } = "Dispair";
        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState =  WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Private Helpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        #endregion 
    }
}

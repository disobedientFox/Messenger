using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Dependency Properties

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        #endregion


        #region Constructor
        public TextEntryControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Dependency callback

        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}

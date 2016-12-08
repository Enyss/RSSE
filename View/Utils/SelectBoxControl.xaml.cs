using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSE
{
    /// <summary>
    /// Logique d'interaction pour SelectBox.xaml
    /// </summary>
    public partial class SelectBoxControl : UserControl
    {
        public SelectBoxControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(SelectBoxControl), new PropertyMetadata(null));
        public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable<object>), typeof(SelectBoxControl), new PropertyMetadata(null));
        public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectBoxControl), new PropertyMetadata(null));

        #region AddItem
        public static  DependencyProperty AddItemProperty =
            DependencyProperty.Register(
                "AddItem",
                typeof(ICommand),
                typeof(SelectBoxControl),
                new UIPropertyMetadata(null));
        public ICommand AddItem
        {
            get { return (ICommand)GetValue(AddItemProperty); }
            set { SetValue(AddItemProperty, value); }
        }
        #endregion

        #region RemoveItem
        public static readonly DependencyProperty RemoveItemProperty =
            DependencyProperty.Register(
                "RemoveItem",
                typeof(ICommand),
                typeof(SelectBoxControl),
                new UIPropertyMetadata(null));
        public ICommand RemoveItem
        {
            get { return (ICommand)GetValue(RemoveItemProperty); }
            set { SetValue(RemoveItemProperty, value); }
        }
        #endregion

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public object SelectedItem
        {
            get { return GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
    }
}

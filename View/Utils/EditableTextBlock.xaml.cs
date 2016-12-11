using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
    /// Logique d'interaction pour EditableTextBlock.xaml
    /// </summary>
    public partial class EditableTextBlock : UserControl
    {
            public EditableTextBlock()
            {
                InitializeComponent();
            }

            public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }

            // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBlock), new UIPropertyMetadata());

            private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
            {
                var txtBlock = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];

                txtBlock.Visibility = Visibility.Visible;
                ((TextBox)sender).Visibility = Visibility.Collapsed;
            }

            private void textBlockName_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ClickCount < 2)
                    return;

                var grid = ((Grid)((TextBlock)sender).Parent);
                var tbx = (TextBox)grid.Children[1];
                ((TextBlock)sender).Visibility = Visibility.Collapsed;
                tbx.Visibility = Visibility.Visible;

                this.Dispatcher.BeginInvoke((Action)(() => Keyboard.Focus(tbx)), DispatcherPriority.Render);
                
            }

            private void TextBoxKeyDown(object sender, KeyEventArgs e)
            {
                if (e == null) return;

                if (e.Key == Key.Return)
                {
                    textBoxName_LostFocus(sender, null);
                }
            }
        }
    }


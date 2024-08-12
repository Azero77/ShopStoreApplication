using ShopApplication.Converters;
using ShopApplication.ViewModels;
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

namespace ShopApplication.Views
{
    /// <summary>
    /// Interaction logic for MakeProductView.xaml
    /// </summary>
    public partial class MakeProductView : UserControl
    {
        public MakeProductView()
        {
            InitializeComponent();
            

        }

        /*private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            
            BindingExpression bindingExpression = box.GetBindingExpression(ComboBox.SelectedItemProperty);
            if (bindingExpression is not null)
            {
                Binding binding = bindingExpression.ParentBinding;
                var viewModel = (MakeProductViewModel)this.DataContext;
                Binding newBinding = new Binding()
                {
                    Path = binding.Path,
                    Converter = new CategoryConverter()
                    {
                        CategoryDictionary =
                    viewModel.Categories!.ToDictionary
                    ((c) => c.Id , (c) => c.Name)!
                    }
            };
                box.SetBinding(ComboBox.SelectedItemProperty, newBinding);
                var result = viewModel.Categories.First(c => viewModel.CategoryId == c.Id);
                box.SelectedItem = result;
                MessageBox.Show(box.SelectedItem.ToString());
            }
        }*/
    }
}

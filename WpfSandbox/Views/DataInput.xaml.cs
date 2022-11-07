using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfSandbox.Views
{
    /// <summary>
    /// Interaction logic for DataInput.xaml
    /// </summary>
    public partial class DataInput : UserControl
    {
        private readonly ProductContext _context = new ProductContext();

        private CollectionViewSource categoryViewSource;

        public DataInput()
        {
            InitializeComponent();
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier to get up and running
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Categories.Load();

            // bind to the source
            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

      
        private async void Control_Unloaded(object sender, RoutedEventArgs e)
        {
            await _context.DisposeAsync();
        }
    }
}

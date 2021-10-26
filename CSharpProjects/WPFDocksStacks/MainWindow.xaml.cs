using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFDocksStacks
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    private string _searchText;

    public string SearchText
    {
      get { return _searchText; }
      set
      {
        _searchText = value;

        OnPropertyChanged("SearchText");
        OnPropertyChanged("MyFilteredItems");
      }
    }

    public List<string> MyItems { get; set; }

    public IEnumerable<string> MyFilteredItems
    {
      get
      {
        if (SearchText == null) return MyItems;

        return MyItems.Where(x => x.ToUpper().StartsWith(SearchText.ToUpper()));
      }
    }


    public MainWindow()
    {
      InitializeComponent();

      MyItems = new List<string>() { "ABC", "DEF", "GHI" };

      // test comment for pushes

      

      this.DataContext = this;
    }

    public ICommand EnterKeyCommand
    {
      get;
      private set;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
  }
}

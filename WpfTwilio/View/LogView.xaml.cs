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
using WpfTwilio.Controller;

namespace WpfTwilio.View
{
    /// <summary>
    /// Interaction logic for MensagensView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            Controller = new LogController();
            DataContext = Controller;
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the controller for this view
        /// </summary>
        public LogController Controller { get; private set; }

    }
}

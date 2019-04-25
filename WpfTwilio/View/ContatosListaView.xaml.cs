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
using WpfTwilio.Model;
using WpfTwilio.Controller;

namespace WpfTwilio.View
{
    /// <summary>
    /// Interaction logic for ContatosListaView.xaml
    /// </summary>
    public partial class ContatosListaView : UserControl
    {
        public ContatosListaView()
        {
            Controller = new ContatosListaController();
            DataContext = Controller;
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the controller for this view
        /// </summary>
        public ContatosListaController Controller { get; private set; }
    }
}

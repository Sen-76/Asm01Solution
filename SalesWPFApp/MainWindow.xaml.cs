using DataAccess.Repository;
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

namespace SalesWPFApp
{
    public partial class MainWindow : Window
    {
        private readonly IMemberRepository _memberService;
        private readonly IOrderRepository _orderService;
        private readonly IProductRepository _productService;
        private readonly IOrderDetailRepository _orderDetailService;
        public MainWindow(IMemberRepository memberService, IOrderRepository orderRepository, IProductRepository productService, IOrderDetailRepository orderDetailService)
        {
            InitializeComponent();
            _memberService = memberService;
            _orderService = orderRepository;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin windowLogin = new WindowLogin(_memberService, _orderService, _productService, _orderDetailService);
            windowLogin.Show();
        }
    }
}

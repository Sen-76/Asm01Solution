using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    public partial class WindowLogin : Window
    {
        private readonly IMemberRepository _memberService;
        private readonly IOrderRepository _orderService;
        private readonly IProductRepository _productService;
        private readonly IOrderDetailRepository _orderDetailService;
        public WindowLogin(IMemberRepository memberService, IOrderRepository orderRepository, IProductRepository productService, IOrderDetailRepository orderDetailService)
        {
            InitializeComponent();
            _memberService = memberService;
            _orderService = orderRepository;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MemberRepository = new MemberRepository();
            string email = inputEmail.Text;
            string password = inputPassword.Password;
            try
            {
                if (App.Admin.UserName.Equals(email) && App.Admin.Password.Equals(password)){
                    alert.Visibility = Visibility.Collapsed;
                    this.Hide();
                    WindowMember windowMember = new WindowMember(_memberService, _orderService, _productService, _orderDetailService);
                    windowMember.Show();
                }else if(_memberService.Login(email, password) != null){
                    this.Hide();
                    Profile windowProfile = new Profile(_memberService.Login(email, password), _memberService, _orderService);
                    windowProfile.Show();
                }
                else
                {
                    MessageBox.Show("Login failed!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    alert.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

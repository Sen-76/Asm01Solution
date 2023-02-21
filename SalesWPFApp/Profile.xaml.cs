using BusinessObject;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public readonly Member _user;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        public Profile(Member user, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _user = user;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            memberIdInput.Text = _user.MemberId.ToString();
            emailInput.Text = _user.Email;
            cNameInput.Text = _user.CompanyName;
            cityInput.Text = _user.City;
            countryInput.Text = _user.Country;
            passwordInput.Text = _user.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member newUser = new Member()
                {
                    MemberId = _user.MemberId,
                    Email = emailInput.Text,
                    CompanyName = cNameInput.Text,
                    City = cityInput.Text,
                    Country = countryInput.Text,
                    Password = passwordInput.Text,
                };
                if (_memberRepository.EmailExist(newUser))
                {
                    MessageBox.Show("Email existed", "Save change failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {   
                _memberRepository.Update(newUser);
                    MessageBox.Show("Okey", "Save change okey", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save change failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData_Grid(object sender, RoutedEventArgs e)
        {
            try
            {
                data.ItemsSource = _orderRepository.OrderByMemberId(_user.MemberId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load data failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

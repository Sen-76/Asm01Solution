using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowMember.xaml
    /// </summary>
    public partial class WindowMember : Window
    {
        private readonly IMemberRepository _memberService;
        private readonly IOrderRepository _orderService;
        private readonly IProductRepository _productService;
        private readonly IOrderDetailRepository _orderDetailService;
        public WindowMember(IMemberRepository memberService, IOrderRepository orderRepository, IProductRepository productService, IOrderDetailRepository orderDetailService)
        {
            InitializeComponent();
            _memberService = memberService;
            _orderService = orderRepository;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Member emp in data.SelectedItems)
                {
                    _orderService.DeleteByMemberId(emp.MemberId.ToString());
                    _memberService.Delete(emp.MemberId.ToString());
                }
                LoadData_Grid(sender, e);
                Reset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            addBtn.IsEnabled = true;
            deleteBtn.IsEnabled = false;
            updateBtn.IsEnabled = false;
            memberIdInput.Text = "";
            emailInput.Text = "";
            cNameInput.Text = "";
            cityInput.Text = "";
            countryInput.Text = "";
            passwordInput.Text = "";
        }

        private void LoadData_Grid(object sender, RoutedEventArgs e)
        {
            try
            {
                data.ItemsSource = _memberService.AllMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load data failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                addBtn.IsEnabled = false;
                deleteBtn.IsEnabled = true;
                updateBtn.IsEnabled = true;
                foreach (Member emp in data.SelectedItems)
                {
                    memberIdInput.Text = emp.MemberId.ToString().Trim();
                    emailInput.Text = emp.Email.Trim();
                    cNameInput.Text = emp.CompanyName.Trim();
                    cityInput.Text = emp.City.Trim();
                    countryInput.Text = emp.Country.Trim();
                    passwordInput.Text= emp.Password.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load data failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member em = new Member()
                {
                    MemberId= int.Parse(memberIdInput.Text.Trim()),
                    Email= emailInput.Text.Trim(),
                    CompanyName= cNameInput.Text.Trim(),
                    City= cityInput.Text.Trim(),
                    Country=countryInput.Text.Trim(),
                    Password=passwordInput.Text.Trim()
                };
                _memberService.Add(em);
                LoadData_Grid(sender, e);
                Reset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Member em = new Member()
                {
                    MemberId= int.Parse(memberIdInput.Text.Trim()),
                    Email= emailInput.Text.Trim(),
                    CompanyName= cNameInput.Text.Trim(),
                    City= cityInput.Text.Trim(),
                    Country=countryInput.Text.Trim(),
                    Password=passwordInput.Text.Trim()
                };
                _memberService.Update(em);
                LoadData_Grid(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void searchinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var searchtxt = searchinput.Text;
                List<Member> searchresult = _memberService.Search(searchtxt);
                data.ItemsSource = searchresult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                WindowOrder windowOrder = new WindowOrder(_memberService, _orderService, _productService, _orderDetailService);
                windowOrder.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Action failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                WindowProduct windowProduct = new WindowProduct(_memberService, _orderService, _productService, _orderDetailService);
                windowProduct.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Action failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

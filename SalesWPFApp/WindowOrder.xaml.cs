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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        private readonly IMemberRepository _memberService;
        private readonly IOrderRepository _orderService;
        private readonly IProductRepository _productService;
        private readonly IOrderDetailRepository _orderDetailService;
        public WindowOrder(IMemberRepository memberService, IOrderRepository orderRepository, IProductRepository productService, IOrderDetailRepository orderDetailService)
        {
            InitializeComponent();
            _memberService = memberService;
            _orderService = orderRepository;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }
        private void LoadData_Grid(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = _orderService.AllOrder();
            memberCbBox.ItemsSource= _memberService.AllMember().Select(x => x.MemberId);
            //memberCbBox.ItemsSource= _memberRepository.AllMember().Select(x => x.Email);
            memberCbBox.SelectedIndex = 0;
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                addBtn.IsEnabled = false;
                deleteBtn.IsEnabled = true;
                updateBtn.IsEnabled = true;
                foreach (Order emp in data.SelectedItems)
                {
                    //var Email = _memberRepository.Get(emp.MemberId.ToString()).Email;
                    orderInput.Text = emp.OrderId.ToString().Trim();
                    memberCbBox.SelectedItem= emp.MemberId;
                    orderDateInput.Text = emp.OrderDate.ToString();
                    requiredDateInput.Text = emp.RequiredDate.ToString()?.Trim();
                    shippedDateInput.Text = emp.ShippedDate.ToString()?.Trim();
                    freightInput.Text = emp.Freight.ToString()?.Trim();
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
                Order em = new Order()
                {
                    OrderDate = Convert.ToDateTime(orderDateInput.Text.Trim()),
                    RequiredDate = requiredDateInput.Text.Trim().Length > 0 ? Convert.ToDateTime(requiredDateInput.Text.Trim()) : null,
                    ShippedDate = shippedDateInput.Text.Trim().Length > 0 ? Convert.ToDateTime(shippedDateInput.Text.Trim()) : null,
                    Freight = freightInput.Text.Trim().Length > 0 ? Convert.ToDecimal(freightInput.Text.Trim()) : null,
                    MemberId = Convert.ToInt32(memberCbBox.SelectedItem),
                };
                _orderService.Add(em);
                LoadData_Grid(sender, e);
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
                foreach (Order emp in data.SelectedItems)
                {
                    _orderDetailService.DeleteOrder(emp.OrderId);
                    _orderService.Delete(emp.OrderId.ToString());
                }
                LoadData_Grid(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Order em = new Order()
                {
                    OrderId = Convert.ToInt32(orderInput.Text.Trim()),
                    OrderDate = Convert.ToDateTime(orderDateInput.Text.Trim()),
                    RequiredDate = requiredDateInput.Text.Trim().Length > 0 ? Convert.ToDateTime(requiredDateInput.Text.Trim()) : null,
                    ShippedDate = shippedDateInput.Text.Trim().Length > 0 ? Convert.ToDateTime(shippedDateInput.Text.Trim()) : null,
                    Freight = freightInput.Text.Trim().Length > 0 ? Convert.ToDecimal(freightInput.Text.Trim()) : null,
                    MemberId = Convert.ToInt32(memberCbBox.SelectedItem),
                };
                _orderService.Update(em);
                LoadData_Grid(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addBtn.IsEnabled = true;
            deleteBtn.IsEnabled = false;
            updateBtn.IsEnabled = false;
            orderInput.Text = "";
            orderDateInput.Text = "";
            requiredDateInput.Text = "";
            shippedDateInput.Text = "";
            freightInput.Text = "";
            memberCbBox.SelectedIndex = 0;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                WindowMember windowMember = new WindowMember(_memberService, _orderService, _productService, _orderDetailService);
                windowMember.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Action failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
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

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
    /// Interaction logic for WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        private readonly IMemberRepository _memberService;
        private readonly IOrderRepository _orderService;
        private readonly IProductRepository _productService;
        private readonly IOrderDetailRepository _orderDetailService;
        public WindowProduct(IMemberRepository memberService, IOrderRepository orderRepository, IProductRepository productService, IOrderDetailRepository orderDetailService)
        {
            InitializeComponent();
            _memberService = memberService;
            _orderService = orderRepository;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }
        private void LoadData_Grid(object sender, RoutedEventArgs e)
        {
            try
            {
                data.ItemsSource = _productService.AllProduct();
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
                foreach (Product emp in data.SelectedItems)
                {
                    //var Email = _memberRepository.Get(emp.MemberId.ToString()).Email;
                    productidInput.Text = emp.ProductId.ToString().Trim();
                    cateInput.Text= emp.CategoryId.ToString().Trim();
                    pNameInput.Text = emp.ProductName.Trim();
                    weightInput.Text = emp.Weight.ToString().Trim();
                    unitPriceInput.Text = emp.UnitPrice.ToString().Trim();
                    UISInput.Text = emp.UnitsInStock.ToString().Trim();
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
                Product em = new Product()
                {
                    ProductId = int.Parse(productidInput.Text.Trim()),
                    CategoryId = int.Parse(cateInput.Text.Trim()),
                    ProductName = pNameInput.Text.Trim(),
                    Weight = unitPriceInput.Text.Trim(),
                    UnitPrice = Convert.ToDecimal(unitPriceInput.Text.Trim()),
                    UnitsInStock = int.Parse(UISInput.Text.Trim()),
                };
                _productService.Add(em);
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
                foreach (Product emp in data.SelectedItems)
                {
                    _orderDetailService.DeleteProduct(emp.ProductId);
                    _productService.Delete(emp.ProductId.ToString());
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
                Product em = new Product()
                {
                    ProductId = int.Parse(productidInput.Text.Trim()),
                    CategoryId = int.Parse(cateInput.Text.Trim()),
                    ProductName = pNameInput.Text.Trim(),
                    Weight = unitPriceInput.Text.Trim(),
                    UnitPrice = Convert.ToDecimal(unitPriceInput.Text.Trim()),
                    UnitsInStock = int.Parse(UISInput.Text.Trim()),
                };
                _productService.Update(em);
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
            productidInput.Text = "";
            cateInput.Text = "";
            pNameInput.Text = "";
            weightInput.Text = "";
            unitPriceInput.Text = "";
            UISInput.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {   
                this.Hide();
                WindowMember windowOrder = new WindowMember(_memberService, _orderService, _productService, _orderDetailService);
                windowOrder.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Action failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

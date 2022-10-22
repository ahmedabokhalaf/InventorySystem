using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem.InventoryDB;
using InventorySystem.Services;


namespace InventorySystem
{
    public partial class Form1 : Form
    {
        CategoryServcices categoryServcices = new CategoryServcices();
        SupplierServices supplierServices = new SupplierServices();
        CustomerServices customerServices = new CustomerServices();
        ItemServices itemServices = new ItemServices();
        SalesManServices salesManServices = new SalesManServices();
        BillServices billServices = new BillServices();
        ItemBillServices itemBillServices = new ItemBillServices();
        List<ShowBill> showBills = new List<ShowBill>();
        MyDBContext context = new MyDBContext();
        
        #region Form Load
        public Form1()
        {
            InitializeComponent();

            categoryForItemComboB.DisplayMember = "Name";
            categoryForItemComboB.ValueMember = "ID";
            categoryForItemComboB.DataSource = null;

            supplierForItemComboB.DisplayMember = "Name";
            supplierForItemComboB.ValueMember = "ID";
            supplierForItemComboB.DataSource = null;

            customerForBillComboBox.DisplayMember = "Name";
            customerForBillComboBox.ValueMember = "ID";
            customerForBillComboBox.DataSource = null;
            customerForBillComboBox.DataSource = customerServices.getAllCustomer();

            salesManForBillComboBox.DisplayMember = "Name";
            salesManForBillComboBox.ValueMember = "ID";
            salesManForBillComboBox.DataSource = null;
            salesManForBillComboBox.DataSource = salesManServices.getAllSalesMan();

            categoryForBillComboBox.DisplayMember = "Name";
            categoryForBillComboBox.ValueMember = "ID";
            categoryForBillComboBox.DataSource = null;
            categoryForBillComboBox.DataSource = categoryServcices.getAllCategory();

            itemsDataGrideView.DataSource = null;
        } 
        #endregion
        

        #region Add Category
        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            if (!(categoryNameTxtBox.Text == string.Empty))
            {
                categoryServcices.Add(categoryNameTxtBox.Text);
                MessageBox.Show("Successfully Inserted");
            }
            else
            {
                MessageBox.Show(" Enter Data To All Field");
            }
        }
        #endregion

        #region Add New Item
        private void saveItemBtn_Click(object sender, EventArgs e)
        {
            int buyPrice = (int)(buyPriceForItemNum.Value);
            int sellPrice = (int)(sellPriceForItemNum.Value);
            int quantity = (int)quantityForItemNum.Value;
            int catID = categoryForItemComboB.SelectedIndex;
            int supId = supplierForItemComboB.SelectedIndex;
            if (newItemRadio.Checked)
            {
                if (!(nameItemForItemTxtBox.Text == string.Empty))
                {
                    itemServices.Add(nameItemForItemTxtBox.Text, buyPrice, sellPrice, quantity, catID, supId);
                    MessageBox.Show($"Successfully Inserted");
                }
                else
                {
                    MessageBox.Show($"Enter Data To All Field");
                }
            }
            else if (existItemRadio.Checked)
            {
                itemServices.update(int.Parse(idItemForItem.Text.ToString()), nameItemForItemTxtBox.Text, buyPrice, sellPrice, quantity, catID, supId);
                MessageBox.Show($"Successfully Updated");
                itemsDataGrideView.DataSource = null;
                itemsDataGrideView.DataSource = context.Items.Select(i => i).ToList();
                hideSomeColumn();
            }
        }
       
        private void itemsDataGrideView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in itemsDataGrideView.SelectedRows)
            {
                idItemForItem.Text = row.Cells[0].Value.ToString();
                nameItemForItemTxtBox.Text = row.Cells[1].Value.ToString();
                buyPriceForItemNum.Value = int.Parse(row.Cells[2].Value.ToString());
                sellPriceForItemNum.Value = int.Parse(row.Cells[3].Value.ToString());
                quantityForItemNum.Value = int.Parse(row.Cells[4].Value.ToString());
                categoryForItemComboB.Text = row.Cells[6].Value.ToString();
                if (row.Cells[8].Value != null)
                {
                    supplierForItemComboB.Text = row.Cells[8].Value.ToString();
                }
                else
                {
                    MessageBox.Show("You must First Choose Category");
                }
            }
        }
        private void newItemRadio_CheckedChanged(object sender, EventArgs e)
        {
            supplierForItemComboB.DataSource = context.Suppliers.Select(s => s).ToList();
            categoryForItemComboB.DataSource = context.Categories.Select(c => c).ToList();
            itemsDataGrideView.DataSource = null;
        }
        private void existItemRadio_CheckedChanged(object sender, EventArgs e)
        {
            supplierForItemComboB.DataSource = context.Suppliers.Select(s => s).ToList();
            categoryForItemComboB.DataSource = context.Categories.Select(c => c).ToList();
            itemsDataGrideView.DataSource = null;
            itemsDataGrideView.DataSource = context.Items.Select(i => i).ToList();
            hideSomeColumn();
        }
        #endregion

        #region Add Supplier
        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            int phone = int.Parse(phoneOfSupplierTxtBox.Text);
            if (!(phoneOfSupplierTxtBox.Text == string.Empty || nameOfSupplierTxtBox.Text == string.Empty || addressOfSupplierTxtBox.Text == string.Empty))
            {
                supplierServices.Add(nameOfSupplierTxtBox.Text, phone, addressOfSupplierTxtBox.Text);
                MessageBox.Show("Successfully Inserted");
            }
            else
            {
                MessageBox.Show(" Enter Data To All Field");
            }
        }
        #endregion

        #region Add Customer
        private void button_customeradd_Click(object sender, EventArgs e)
        {
            int phone = int.Parse(textBox2_customerphone.Text);
            if (!(textBox2_customerphone.Text == string.Empty || textBox1_namecustomer.Text == string.Empty || textBox3_customerAddress.Text == string.Empty))
            {
                customerServices.Add(textBox1_namecustomer.Text, phone, textBox3_customerAddress.Text);
                MessageBox.Show("Successfully Inserted");
            }
            else
            {
                MessageBox.Show(" Enter Data To All Field");
            }
        }
        #endregion

        #region Add SalesMan
        private void button1_Addsalesman_Click(object sender, EventArgs e)
        {
            if (!(textBox1_salesmanName.Text == string.Empty || textBox2_salesmanPhone.Text == string.Empty || textBox3_salesmanAddress.Text == string.Empty))
            {
                int phone = int.Parse(textBox2_salesmanPhone.Text);
                salesManServices.Add(textBox1_salesmanName.Text, phone, textBox3_salesmanAddress.Text);
                MessageBox.Show("Successfully Inserted");
            }
            else
            {
                MessageBox.Show(" Enter Data To All Field");
            }
        }
        #endregion

        #region BillForm
        private void categoryForBillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Item> itemByCat = new List<Item>();
            itemByCat = itemServices.getItemByCatName(categoryForBillComboBox.SelectedItem.ToString());
            itemForBillComboBox.DataSource = null;
            itemForBillComboBox.DataSource = itemByCat;
        }
       
        private void saveBillBtn_Click(object sender, EventArgs e)
        {
            int catID = categoryServcices.getCatId(categoryForBillComboBox.SelectedItem.ToString());
            int itemID = itemServices.getItemId(itemForBillComboBox.SelectedItem.ToString());
            int customerID = customerServices.getCustomerId(customerForBillComboBox.SelectedItem.ToString());
            int salesManID = salesManServices.getSalesManId(salesManForBillComboBox.SelectedItem.ToString());
            int billId;

            if (!(quantityForBillTxtBox.Text == string.Empty))
            {
                int quantSaled = int.Parse(quantityForBillTxtBox.Text);
                ShowBill showBill = new ShowBill();

                if (itemServices.getItemQuantity(itemID) >= quantSaled)
                {
                   
                    billServices.Add(customerID, salesManID);
                    billId = billServices.getBillId(customerID, salesManID);
                    itemBillServices.Add(billId, itemID, quantSaled);
                   
                    showBill.Category = categoryServcices.getCatName(catID);
                    showBill.Customer = customerServices.getCustomerName(customerID);
                    showBill.Name = itemServices.getItemName(itemID);
                    showBill.Quantity = quantSaled;
                    showBill.SalesMan = salesManServices.getSalesManName(salesManID);
                    showBill.PriceOfPice = itemServices.getItemPrice(itemID);
                    showBill.TotalPrice = (itemServices.getItemPrice(itemID) * quantSaled);
                    itemServices.updateQuantity(itemID, quantSaled);
                    MessageBox.Show($"Successfully Inserted");

                    showBills.Add(showBill);

                }
                else
                {
                    MessageBox.Show($"Quantity of not Enough");
                }

            }
            else
            {
                MessageBox.Show($"Enter Data To All Field");
            }

            billsdataGridView.DataSource = null;
            billsdataGridView.DataSource = showBills;
        }
        #endregion
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Logged Out Successfully ... Have a great day..!");
            this.Close();
        }

        private void AddAcountBtn_Click(object sender, EventArgs e)
        {
            Register R = new Register();
            R.Show();

        }

        private void ManageAccountBtn_Click(object sender, EventArgs e)
        {
            Accounts ac = new Accounts();
            ac.Show();

            UserServices us = new UserServices();
            us.show();
        }
 
        private void showItemInReportBtn_Click(object sender, EventArgs e)
        {
            int num = int.Parse(numberLessThanNumeric.Value.ToString());
            getItemLessThanDataGridView.DataSource = null;
            getItemLessThanDataGridView.DataSource = itemServices.getItemLessThan(num);
        }
       
        private void categoryForItemComboB_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            items = context.Items.Where(i => i.CategoryID == (int)categoryForItemComboB.SelectedValue).ToList();
            itemsDataGrideView.DataSource = null;
            itemsDataGrideView.DataSource = items;
            hideSomeColumn();
        }

        private void tabControl1_MouseClick_1(object sender, MouseEventArgs e)
        {
            DGV4_All.DataSource = null;
            DGV4_All.DataSource = itemServices.getAllItem();
            //hideSomeColumn();
        }
        public void hideSomeColumn()
        {
            itemsDataGrideView.Columns["ID"].Visible = false;
            itemsDataGrideView.Columns["CategoryID"].Visible = false;
            itemsDataGrideView.Columns["SupplierID"].Visible = false;
            itemsDataGrideView.Columns["BillItems"].Visible = false;
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV4Saled.DataSource = null;
            DGV4Saled.DataSource = itemBillServices.getBillByGroup();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = itemBillServices.getStayedItems();



        }

  
    }
}

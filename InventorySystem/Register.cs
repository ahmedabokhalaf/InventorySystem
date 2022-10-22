using InventorySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserServices us = new UserServices();
            us.Add(userNametxtbox.Text, passwordtxtbox.Text);
            MessageBox.Show("your registration completed");
            this.Close();
        }
    }
}

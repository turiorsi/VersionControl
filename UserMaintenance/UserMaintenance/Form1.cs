using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>(); //létrehozta eg yusers listát

        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName; // label1
            btnFajl.Text = Resource1.File;  //így nevezem ét a buttont a property nélkül 
            btndelete.Text = Resource1.delete;
            btnAdd.Text = Resource1.Add; // button1

            listUsers.DataSource = users; //amiket beleírok a usersbe azt a listboxba teszi bele
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName"; //egybe írja ki a nevket
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User() //betöltöm az adatokat amit a textboxokba írunk
            {
                FullName = txtLastName.Text,
               
            };
            users.Add(u);
        }

        private void btnFajl_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //mentés
            if (sfd.ShowDialog()!=DialogResult.OK) //ha ok-kal zárom b akkor mentse el 
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(sfd.FileName,true,Encoding.UTF8)) //fájlba írás
            {
                foreach (var item in users)
                {
                    
                    //sw.Write(item.ID);
                    sw.Write(item.FullName); 

                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listUsers.SelectedIndex);
        }
    }
}

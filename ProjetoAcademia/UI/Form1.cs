﻿using ProjetoAcademia.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcademia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
                 Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UI.frmUsuarios frmUsuarios = new UI.frmUsuarios();
            frmUsuarios.ShowDialog();
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            UI.frmAlunos frmAlunos = new UI.frmAlunos();
            frmAlunos.ShowDialog();
        }
    }
}

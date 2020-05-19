﻿using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.OtherForm
{
    public partial class TeacherForm : Form
    {
        private GenericUnitOfWork work;

        public TeacherForm(GenericUnitOfWork work)
        {
            InitializeComponent();
            this.work = work;
        }
    }
}

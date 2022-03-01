﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LABA2;
using LABA3;

namespace LABA3
{
    public partial class Form2 : Form
    {
        public List<Account> accounts;

        public Form2(List<Account> accounts)
        {
            InitializeComponent();
            this.accounts = accounts;
        }

        private void checksearch_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = checksearch.Checked;
            label3.Visible = checksearch.Checked;
            label4.Visible = checksearch.Checked;
            FIO.Visible = checksearch.Checked;
            BALANCE.Visible = checksearch.Checked;
            TYPE.Visible = checksearch.Checked;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var temp = accounts;
            listBox1.Items.Clear();
            if (!checksearch.Checked)
            {
                var str = textsearch.Text;
                var reg = new Regex(str);
                foreach (var i in accounts)
                {
                    if (reg.IsMatch(i.ToString()))
                    {
                        listBox1.Items.Add(i);
                        return;
                    }
                }
            }
            else
            {
                if (FIO.Text != "")
                {
                    accounts = accounts.Where(x => x.owner.Name.Equals(FIO.Text)).ToList();
                }
                if (BALANCE.Text != "")
                {
                    accounts = accounts.Where(x => x.Balance == int.Parse(BALANCE.Text)).ToList();
                }
                if (TYPE.Text != "")
                {
                    accounts = accounts.Where(x =>
                    {
                        if (TYPE.Text == "Закрытый")
                        {
                            return x.Type == Account.Types.closed;
                        }
                        else
                            return x.Type == Account.Types.open;
                    }).ToList();
                }
            }
            foreach (var item in accounts)
            {
                listBox1.Items.Add(item);
            }
            accounts = temp;
        }
    }
}
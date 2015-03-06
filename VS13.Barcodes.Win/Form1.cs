using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VS13 {
    //
    public partial class Form1 : Form {
        //Members
        private char[] mBarcode;

        //Interface
        public Form1() {
            InitializeComponent();
            this.mBarcode = this.textBox1.Text.ToCharArray();
            this.textBox1.Text = new VS13.Barcode().Encode128AB("1234567890","Code128A",VS13.Barcode128.A);
        }
    }
}

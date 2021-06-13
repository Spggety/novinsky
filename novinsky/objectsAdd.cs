using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace novinsky
{
    class objectsAdd
    {
        static public void ComboName(ComboBox ComboName, int x, int y, string itemBlock)
        {
            // 
            // comboBox
            // 

            ComboName.FormattingEnabled = true;
            ComboName.Location = new Point(453, 190);
            ComboName.Size = new Size(319, 21);
        }
        static public void LabelName(Label LabelName, int x, int y, string textBlock)
        {
            
            // 
            // label
            // 

            LabelName.AutoSize = true;
            LabelName.Location = new Point(x, y);
            LabelName.Text = textBlock;
        }
    }
}

using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace Network_Tool
{
	public partial class Component1 : Component
	{
        
		public Component1()
		{
			InitializeComponent();
		}

		public Component1(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}
		
    }
}

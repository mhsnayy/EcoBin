﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Graduation_Project1
{
    class DataBase
    {
        public NpgsqlConnection connection()
        {
            //NpgsqlConnection connect = new NpgsqlConnection("Host = 192.168.0.12; Port = 5432; Username = postgres; Password = postgres; Database = postgres;Timeout=30; ");
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost; Port=5432; Username=postgres; Database=gp; Timeout=30;");

            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
            else
            {
                MessageBox.Show("Connection is already open. Please close!!");
            }
            return connect;
        }


    }
}

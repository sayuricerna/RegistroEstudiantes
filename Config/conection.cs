﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiantes.Config
{
    internal class conection
    {
        private readonly string varConnection = "Server=localhost\\SQLEXPRESS;Database=RegistroEstudiantes;Trusted_Connection=True";
        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(varConnection);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace App11.Services
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}

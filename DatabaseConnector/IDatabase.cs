﻿// This file is part of Mystery Dungeon eXtended.

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PMDCP.DatabaseConnector
{
    public interface IDatabase
    {
        void CreateTable(string tableName, IDataField[] fields);
        void DeleteTable(string tableName);
        IDataColumn[] RetrieveRow(string tableName, string columns, string filterExpression);
        //List<IDataColumn[]> RetrieveRows(string tableName, string columns, string filterExpression);
        void AddRow(string tableName, IDataColumn[] columns);
        void DeleteRow(string tableName, string filterExpression);
        void OpenConnection();
        void CloseConnection();
        object ExecuteQuery(string command);
        System.Data.ConnectionState ConnectionState { get; }
        int CountRows(string tableName);
        bool TableExists(string tableName);
        void UpdateRow(string tableName, IDataColumn[] columns, string filterExpression);
        void UpdateRow(string tableName, IDataColumn[] columns);
        void UpdateOrInsert(string tableName, IDataColumn[] columns, string filterExpression);
        IDataField CreateField(string name, string type);
        IDataColumn CreateColumn(bool primaryKey, string name, string value);
        void BeginTransaction();
        void EndTransaction();

        string ConnectionString { get; set; }
        bool IsTransactionActive { get; }
    }
}

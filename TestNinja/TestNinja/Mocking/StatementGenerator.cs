using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class StatementGenerator : IStatementGenerator
    {
        public string SaveStatement(int oid, string fullName, DateTime statementDate)
        {
            return "save statement";
        }
    }
}

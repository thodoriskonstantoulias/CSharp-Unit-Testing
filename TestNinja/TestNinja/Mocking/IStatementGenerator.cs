using System;

namespace TestNinja.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int oid, string fullName, DateTime statementDate);
    }
}
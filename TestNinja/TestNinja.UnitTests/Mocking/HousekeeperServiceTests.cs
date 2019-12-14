﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;
using System.Linq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class HousekeeperServiceTests
    {
        private HousekeeperService service;
        private Mock<IStatementGenerator> statementGenerator;
        private Mock<IEmailSender> emailSender;
        private Mock<IXtraMessageBox> messageBox;
        private DateTime statementDate = new DateTime(2019, 1, 1);
        private Housekeeper housekeeper;

        [SetUp]
        public void SetUp()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                housekeeper
            }.AsQueryable());

            statementGenerator = new Mock<IStatementGenerator>();
            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IXtraMessageBox>();

            service = new HousekeeperService(unitOfWork.Object, statementGenerator.Object, emailSender.Object, messageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {            
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(s => s.SaveStatement(housekeeper.Oid,housekeeper.FullName, statementDate));
        }
        [Test]
        public void SendStatementEmails_NullEmail_NotGenerateStatements()
        {
            housekeeper.Email = null;
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(s => s.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate),Times.Never);
        }
        [Test]
        public void SendStatementEmails_WhitespaceEmail_NotGenerateStatements()
        {
            housekeeper.Email = " ";
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(s => s.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate), Times.Never);
        }
    }
}

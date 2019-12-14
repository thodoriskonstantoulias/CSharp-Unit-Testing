using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class HousekeeperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _xtraMessageBox;

        public HousekeeperService(IUnitOfWork unitOfWork, IStatementGenerator statementGenerator, IEmailSender emailSender, IXtraMessageBox xtraMessageBox)
        {
            _unitOfWork = unitOfWork;
            _statementGenerator = statementGenerator;
            _emailSender = emailSender;
            _xtraMessageBox = xtraMessageBox;
        }
        public void SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();
            foreach (var housekeeper in housekeepers)
            {
                if (string.IsNullOrWhiteSpace(housekeeper.Email)) continue;

                var statementFileName = _statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);
                if (string.IsNullOrWhiteSpace(statementFileName)) continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;
                try
                {
                    _emailSender.EmailFile(emailAddress, emailBody, statementFileName, string.Format("Sandpiper statement {0:yyyy-MM} {1}", statementFileName, "test"));
                }
                catch (Exception e)
                {
                    _xtraMessageBox.Show(e.Message,string.Format("Email failure : {0}", emailAddress));
                }
            }
        }       
    }

    public interface IXtraMessageBox
    {
        void Show(string message, string v);
    }

    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string message, string v)
        {

        }
    }
}

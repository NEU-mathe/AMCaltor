namespace ExamSysWinform.WebService
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlInclude(typeof(ClientModelSuper)), GeneratedCode("System.Web.Services", "4.0.30319.34209"), DebuggerStepThrough, DesignerCategory("code"), WebServiceBinding(Name = "StudentServiceSoap", Namespace = "http://tempuri.org/")]
    public class StudentService : SoapHttpClientProtocol
    {
        private SendOrPostCallback ChangePwdOperationCompleted;
        private SendOrPostCallback getServerTimeOperationCompleted;
        private SendOrPostCallback getStuScoreOperationCompleted;
        private SendOrPostCallback getTemplateOperationCompleted;
        private SendOrPostCallback LoginOperationCompleted;
        private SendOrPostCallback saveStudentAnwserOperationCompleted;
        private SendOrPostCallback ShowStuPaperOperationCompleted;
        private SendOrPostCallback UpdateScoreOperationCompleted;
        private bool useDefaultCredentialsSetExplicitly;

        
       // public event getTemplateCompletedEventHandler getTemplateCompleted;

        public StudentService()
        {
            this.Url = "http://202.118.26.80/WebService/StudentService.asmx";
            //if (this.IsLocalFileSystemWebService(this.Url))
            //{
            //    this.UseDefaultCredentials = true;
            //    this.useDefaultCredentialsSetExplicitly = false;
            //}
            //else
            //{
                this.useDefaultCredentialsSetExplicitly = true;
            //}
        }

        [SoapDocumentMethod("http://tempuri.org/Login", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public ClientStudentModel Login(ClientStudentModel selectModel)
        {
            return (ClientStudentModel)base.Invoke("Login", new object[] { selectModel })[0];
        }


        [SoapDocumentMethod("http://tempuri.org/getTemplate", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet getTemplate(string key, string studentNumber, string type, string dataSource)
        {
            return (DataSet)base.Invoke("getTemplate", new object[] { key, studentNumber, type, dataSource })[0];
        }

        [SoapDocumentMethod("http://tempuri.org/ShowStuPaper", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet ShowStuPaper(string key, string stuNumber, string dataSource)
        {
            return (DataSet)base.Invoke("ShowStuPaper", new object[] { key, stuNumber, dataSource })[0];
        }
    }
}


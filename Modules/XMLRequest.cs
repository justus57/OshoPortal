using OshoPortal.WebService_Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace OshoPortal.Modules
{
    public class XMLRequest
    {

    }
    public class LoginXMLRequests
    {
        public static string UserLogin(string username, string password)
        {
            string req = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
                                <Body>
                                    <ConfirmEmployeePassword xmlns=""urn:microsoft-dynamics-schemas/codeunit/PortalLogin"">
                                        <employeeNo>" + username + @"</employeeNo>
                                        <password>" + password + @"</password>
                                    </ConfirmEmployeePassword>
                                </Body>
                            </Envelope>";
            string response = WSConnection.CallWebService(req);
            return WSConnection.GetJSONResponse(response);
        }
    }
    public class OneTimePassXMLRequests
    {
        public static string ChangePassword(string username, string oldpass, string newpass)
        {
            string req = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
                                    <Body>
                                        <ChangeEmployeePassword xmlns=""urn:microsoft-dynamics-schemas/codeunit/PortalLogin"">
                                            <employeeNo>" + username + @"</employeeNo>
                                            <oldPassword>" + oldpass + @"</oldPassword>
                                            <newPassword>" + newpass + @"</newPassword>
                                        </ChangeEmployeePassword>
                                    </Body>
                                </Envelope>";
            string str = WSConnection.CallWebService(req);
            return WSConnection.GetJSONResponse(str);
        }
    }
    public class ForgotPasswordXmlRequest
    {
        public static string ForgotPassword(string username)
        {
            string ResetPassresponseString = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
                                                    <Body>
                                                        <RecoverLostPassword xmlns=""urn:microsoft-dynamics-schemas/codeunit/PortalLogin"">
                                                            <employeeNo>" + username + @"</employeeNo>
                                                        </RecoverLostPassword>
                                                    </Body>
                                                </Envelope>";
            string response = WSConnection.CallWebService(ResetPassresponseString);
            return WSConnection.GetJSONResponse(response);
        }
    }
    public class createRequisition
    {
        public static string Requisition(string name)
        {
            string ResetPassresponseString = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
                                                    <Body>
                                                        <RecoverLostPassword xmlns=""urn:microsoft-dynamics-schemas/codeunit/PortalLogin"">
                                                            <employeeNo>" + name + @"</employeeNo>
                                                        </RecoverLostPassword>
                                                    </Body>
                                                </Envelope>";
            string response = WSConnection.CallWebService(ResetPassresponseString);
            return WSConnection.GetJSONResponse(response);
        }
    }
    public class ProductsXMLRequests
    {
        public static DataTable GetPageData(string status, string owner, string endpoint)
        {
            string LeaveStatus = null;
            string AppliedAs = null;

            if (owner == "self")
            {
                AppliedAs = "Employee";
            }
            else if (owner == "others")
            {
                AppliedAs = "AppliedForAnother";
            }

            if (status == "Open")
            {
                LeaveStatus = "Open";
            }
            else if (status == "Pending")
            {
                LeaveStatus = "PendingApproval";
            }
            else if (status == "Approved")
            {
                LeaveStatus = "Approved";
            }
            else if (status == "Rejected")
            {
                LeaveStatus = "Rejected";
            }

            string username = HttpContext.Current.Session["Username"].ToString();

            string tabledata = GetItemsList.Getitemlist();

            XmlDocument xmlSoapRequest = new XmlDocument();
            //xmlSoapRequest.LoadXml(tabledata);
            int count = 0;

            DataTable table = new DataTable();
            table.Columns.Add("Date Submitted", typeof(string));
            table.Columns.Add("Employee Name", typeof(string));
            table.Columns.Add("Product name", typeof(string));
            table.Columns.Add("Quatity", typeof(string));
            //table.Columns.Add("Start Date", typeof(string));
            //table.Columns.Add("End Date", typeof(string));
            //table.Columns.Add("Leave Days", typeof(string));
            table.Columns.Add("View", typeof(string));


            if (Convert.ToInt16(xmlSoapRequest.GetElementsByTagName("totalRecords")[count].InnerText) > 0)
            {
                foreach (XmlNode xmlNode in xmlSoapRequest.DocumentElement.GetElementsByTagName("LeaveHeader"))
                {

                    XmlNode NodeDateCreated = xmlSoapRequest.GetElementsByTagName("DateCreated")[count];
                    string DateCreated = NodeDateCreated.InnerText;

                    XmlNode NodeEmployeeName = xmlSoapRequest.GetElementsByTagName("EmployeeName")[count];
                    string EmployeeName = NodeEmployeeName.InnerText;

                    XmlNode NodeLeaveCode = xmlSoapRequest.GetElementsByTagName("LeaveCode")[count];
                    string LeaveCode = NodeLeaveCode.InnerText;

                    XmlNode NodeHeaderNo = xmlSoapRequest.GetElementsByTagName("HeaderNo")[count];
                    string HeaderNo = NodeHeaderNo.InnerText;

                    XmlNode NodeStartDate = xmlSoapRequest.GetElementsByTagName("StartDate")[count];
                    string StartDate = NodeStartDate.InnerText;

                    XmlNode NodeEndDate = xmlSoapRequest.GetElementsByTagName("EndDate")[count];
                    string EndDate = NodeEndDate.InnerText;

                    XmlNode NodeLeaveDays = xmlSoapRequest.GetElementsByTagName("LeaveDays")[count];
                    string LeaveDays = NodeLeaveDays.InnerText;

                    XmlNode NodeHeaderNoLink = xmlSoapRequest.GetElementsByTagName("HeaderNo")[count];
                    string HeaderNoLink = NodeHeaderNoLink.InnerText;

                    if (status == "Open")
                    {
                        table.Rows.Add(Functions.ConvertTime(DateCreated), EmployeeName, LeaveCode, HeaderNo, Functions.ConvertTime(StartDate), Functions.ConvertTime(EndDate), LeaveDays, "<a class = 'btn btn-secondary btn-xs' href = " + "ViewLeave.aspx?id=" + Functions.Base64Encode(HeaderNoLink) + "&status=Open" + " data-toggle='tooltip' title='Edit Application'><span class = 'fa fa-edit'> </span></a>  <a class = 'btn btn-success btn-xs submit_record' data-id=" + Functions.Base64Encode(HeaderNoLink) + " data-date=" + Functions.ConvertTime(StartDate) + " href = 'javascript:void(0)' data-toggle='tooltip' title='Submit Application'><span class = 'fa fa-paper-plane'> </span></a> <a class = 'btn btn-danger btn-xs delete_record' data-id=" + Functions.Base64Encode(HeaderNoLink) + " href = 'javascript:void(0)' data-toggle='tooltip' title='Delete Application'><span class = 'fa fa-trash'> </span></a> <a class = 'btn btn-primary btn-xs' href = " + "ViewLeave.aspx?id=" + Functions.Base64Encode(HeaderNoLink) + "&status=Open" + " data-toggle='tooltip' title='View Application'><span class = 'fa fa-eye'> </span></a>");
                    }
                    else if (status == "Pending")
                    {
                        table.Rows.Add(Functions.ConvertTime(DateCreated), EmployeeName, LeaveCode, HeaderNo, Functions.ConvertTime(StartDate), Functions.ConvertTime(EndDate), LeaveDays, "<a class = 'btn btn-danger btn-xs cancel_record' data-id=" + Functions.Base64Encode(HeaderNoLink) + " href = 'javascript:void(0)' data-toggle='tooltip' title='Cancel Application'><span class = 'fa fa-times' > </span></a> <a class = 'btn btn-primary btn-xs' href = " + "ViewLeave.aspx?id=" + Functions.Base64Encode(HeaderNoLink) + "&status=Pending" + " data-toggle='tooltip' title='View Application'><span class = 'fa fa-eye'> </span></a>");
                    }
                    else if (status == "Approved")
                    {
                        table.Rows.Add(Functions.ConvertTime(DateCreated), EmployeeName, LeaveCode, HeaderNo, Functions.ConvertTime(StartDate), Functions.ConvertTime(EndDate), LeaveDays, "<a class = 'btn btn-primary btn-xs' href = " + "ViewLeave.aspx?id=" + Functions.Base64Encode(HeaderNoLink) + "&status=Approved" + " data-toggle='tooltip' title='View Application'><span class = 'fa fa-eye'> </span></a>");
                    }
                    else if (status == "Rejected")
                    {
                        table.Rows.Add(Functions.ConvertTime(DateCreated), EmployeeName, LeaveCode, HeaderNo, Functions.ConvertTime(StartDate), Functions.ConvertTime(EndDate), LeaveDays, "<a class = 'btn btn-primary btn-xs' href = " + "ViewLeave.aspx?id=" + Functions.Base64Encode(HeaderNoLink) + "&status=Rejected" + " data-toggle='tooltip' title='View Application'><span class = 'fa fa-eye'> </span></a>");
                    }

                    count++;
                }
            }

            return table;
        }
    }
    public class GetItemsList
    {
        public static string Getitemlist()
        {
            string reqitem = @"";
            string response = WSConnection.CallWebService(reqitem);
            return WSConnection.GetJSONResponse(response);
        }
    }
}
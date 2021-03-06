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
    public class ItemRequest
    {
        public static string itemList(string username)
        {
            string itemlist = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
                            <Body>
                                <GetItemList xmlns=""urn:microsoft-dynamics-schemas/codeunit/webportal"">
                                    <itemList>
                                        <Item xmlns=""urn:microsoft-dynamics-nav/xmlports/x51200""/>
                                    </itemList>
                                    <employeeNo>"+ username + @"</employeeNo>
                                </GetItemList>
                            </Body>
                        </Envelope>";
            string response = WSConnection.CallWebService(itemlist);
            return WSConnection.GetJSONResponse(response);
        }
    }
}
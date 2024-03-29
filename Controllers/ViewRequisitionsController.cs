﻿using OshoPortal.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class ViewRequisitionsController : Controller
    {
        // GET: ViewRequisitions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewRequisitions()
        {
            return View();
        }
        private void LoadTable(string status, string owner, string endpoint)
        {
            DataTable dt;

            if (owner == "self")
            {
                dt = ProductsXMLRequests.GetPageData(status, owner, endpoint);
            }
            else if (owner == "others")
            {
                dt = ProductsXMLRequests.GetPageData(status, owner, endpoint);
            }
            else
            {
                dt = ProductsXMLRequests.GetPageData(status, owner, endpoint);
            }
            //Building an HTML string.
            StringBuilder html = new StringBuilder();
            //Table start.
            html.Append("<table class='table table-bordered' id='dataTable' width='100%' cellspacing='0'>");
            //Building the Header row.
            html.Append("<thead>");
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("</thead>");

            html.Append("<tfoot>");
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("</tfoot>");

            //Building the Data rows.
            html.Append("<tbody>");
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</tbody>");
            //Table end.
            html.Append("</table>");
            string strText = html.ToString();

            ViewBag.Table = strText;
        }
    }
}
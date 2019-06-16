using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PdvStock.Utils
{
    public class EmailTemplate
    {
        

        public static String Email(String conteudo)
        {
            String html = "<!DOCTYPE html>";
            html += "<html lang=\"pt-br\">";
            html += "<body style=\"margin:0px !important;padding:0px !important;\">";
            html += "<div class=\"body\" style =\"margin:20px !important;padding:0px !important;\">"
                    + "<style>"
                         + ".btn {  -webkit-border-radius: 28;  -moz-border-radius: 28;  border-radius: 28px;  font-family: Arial;  color: #ffffff;  font-size: 20px;  background: #7ac143;  padding: 10px 20px 10px 20px;  text-decoration: none;} .btn:hover {  background: #67a138;  text-decoration: none; }"
                    +"</style>";
            html += "<p>";
            html += "<div class=\"row\">";
            html += "<div class=\"span2\">";
            html += "<img src=\"https://ci4.googleusercontent.com/proxy/xJ0yW9mtaaaY1uklnzesD4UjTg4RoK7Z1HaTnYO9U1xEwPdAD1lZP1AGIsM3-wltVpDuBXYKMYRmzkl9p-o=s0-d-e1-ft#http://intranet.butantan.gov.br/PublishingImages/lgo/lgoButantanIntra.png\"/>";
            html += "</div>";
            html += "</div>";
            html += "</p>";
            html += "<p>";
            html += "<div class=\"msg_nav\" style=\"background-color:#555;height:4px;\">";
            html += "</div>";
            html += "</p>";
            html += "<p>";
            html += "<div class=\"msg_info\" style=\"padding: 30px;margin-bottom: 30px;font-weight: 200;color: inherit;background-color: #eeeeee;\">";
            html += conteudo;
            html += "</div>";
            html += "</p>";
            html += "</div>";
            html += "</body>";
            html += "</html>";
            return html;
        }
      
    }
}

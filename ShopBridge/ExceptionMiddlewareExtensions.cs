using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopBridge
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IHostEnvironment env, string ConnString)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var error = contextFeature.Error;
                        string strMessage = string.Empty;
                        //Write the log to Database
                        EXceptionLogInsert eXceptionLogInsert = new EXceptionLogInsert(ConnString);
                        int? LogID = eXceptionLogInsert.LastExceptionId();
                        LogID = LogID == null ? 0 + 1 : LogID + 1;
                        int returnid = eXceptionLogInsert.WriteLogDataBase(Convert.ToInt32(LogID), error.Message, error.StackTrace);
                        if (returnid > 0)
                        {
                            strMessage = "Log Id :" + LogID;
                        }
                        else
                        {
                            strMessage = "Oops!. Something went wrong.";
                        }

                        if (env.IsDevelopment())
                        {
                            string strJsonResult = JsonConvert.SerializeObject(new Response
                            {
                                ErrorMessage = strMessage,
                                StatusCode = 500
                            });
                            Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
                            await context.Response.WriteAsync(strJsonResult).ConfigureAwait(false);
                        }
                        else
                        {
                            string strJsonResult = JsonConvert.SerializeObject(new Response
                            {
                                ErrorMessage = strMessage,
                                StatusCode = 500
                            });
                            await context.Response.WriteAsync(strJsonResult).ConfigureAwait(false);
                        }
                    }

                });
            });
        }
    }

    public class Response
    {
        public static string ContentType { get; internal set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class EXceptionLogInsert
    {
        string ConnString = string.Empty;
        public EXceptionLogInsert(string ConnectionString)
        {
            ConnString = ConnectionString;
        }
        public int? LastExceptionId()
        {
            int? myLogId = 0;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                myLogId = connection.QueryFirst<int?>("SELECT MAX(LogId) LogId FROM T_ExceptionLog"); //Here implemented the Dapper ORM
            }
            return myLogId;
        }
        public int WriteLogDataBase(int LogId, string ExcMessage, string StackTrace)
        {
            int returnid = 0;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                string sqlQuery = "INSERT INTO T_ExceptionLog VALUES(" + LogId + ",'" + ExcMessage + "',GETDATE(),'" + StackTrace + "')"; //Here implemented the Dapper ORM
                try
                {
                    returnid = connection.Execute(sqlQuery);
                }
                catch (Exception e)
                {

                }
            }
            return returnid;
        }
    }
}

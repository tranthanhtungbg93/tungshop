using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Model;
using TeduShop.Service.Error;

namespace TeduShop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private ILogError _logError;
        public ApiControllerBase(ILogError logError)
        {
            _logError = logError;
        }

        protected HttpResponseMessage CreateHttpRes(HttpRequestMessage res, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage http = null;
            try
            {
                http = func.Invoke();
            }
            catch (DbEntityValidationException validEx)
            {
                foreach (var exeve in validEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type  \"{exeve.Entry.Entity.GetType().Name}\"" +
                        $" in state \"{exeve.Entry.State}\" has the following validate error :"
                        );
                    foreach (var ex in exeve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property : \"{ex.PropertyName}\", error: \"{ex.ErrorMessage}");
                    }
                }
                LogErrorFuction(validEx);
                http = res.CreateErrorResponse(HttpStatusCode.BadRequest, validEx.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogErrorFuction(dbEx);
                http = res.CreateErrorResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogErrorFuction(ex);
                http = res.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return http;
        }

        private void LogErrorFuction(Exception ex)
        {
            try
            {
                LogError err = new LogError();
                err.CreatedDate = DateTime.Now;
                err.Massage = ex.Message;
                err.StackTrace = ex.StackTrace;

                _logError.Create(err);
                _logError.Save();
            }
            catch
            {

            }
        }
    }
}

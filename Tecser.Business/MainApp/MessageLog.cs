using System;
using System.Linq;
using TecserEF.Entity;

namespace Tecser.Business.MainApp
{
    public class MessageLog
    {
        public void AddMessageLog(string tcode, string errorCode, string mensaje1, string mensaje2 = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new TL001_MsgLog
                {
                    UserLog = Environment.UserName,
                    ComputerLog = System.Environment.MachineName,
                    FechaLog = DateTime.Now,
                    TCode = tcode,
                    ErrorCode = errorCode,
                    Mensaje1 = mensaje1,
                    Mensaje2 = mensaje2
                };

                if (!db.TL001_MsgLog.Any())
                {
                    data.IdLog = 1;
                }
                else
                {
                    data.IdLog = db.TL001_MsgLog.Max(c => c.IdLog) + 1;
                }
                db.TL001_MsgLog.Add(data);
                db.SaveChanges();
            }
        }
    }
}

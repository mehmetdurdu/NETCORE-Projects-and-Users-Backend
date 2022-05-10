using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this sınıfı ifade eder ve sınıfa seçilen constructor gönderilirse o constructor da çalışır.
        //İlk constructor ile istenilen sonuç elde edilebilir.Hem başarı durumu hem mesaj durumu.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        //Sadece başarı durumu istenirse kullanılır.
        public Result(bool success)
        {
            Success = success;
        }

        //Get olarak tanımlandı ve set edilemez.
        //Yalnızca contsructor da set edilebilir. 
        public bool Success { get; }

        //Get olarak tanımlandı ve set edilemez.
        //Yalnızca contsructor da set edilebilir. 
        public string Message { get; }
    }
}

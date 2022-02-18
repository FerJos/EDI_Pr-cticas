using System;

namespace Lab2.Models
{
    public class ErrorViewModel
    {

        public string Equipo { get; set; }
        public string Coach { get; set; }
        public string Liga { get; set; }
        public string Fecha { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

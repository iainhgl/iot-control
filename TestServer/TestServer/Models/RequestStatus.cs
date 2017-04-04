using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Models
{
    public enum RequestStatusTypes
    {
        Sent = 0,
        InTransit = 1,
        Processing = 2,
        Complete = 3,
    }

    public class RequestStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string SourceId { get; set; }
        public string Id { get; set; }
        public RequestStatusTypes Status { get; set; }
        public DateTime Timestamp { get; set; }
        public RequestStatus Child { get; set; }
    }
}

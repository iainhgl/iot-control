using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string Id { get; set; }
        public string GroupId { get; set; }
        public int OrderInGroup { get; set; }
        public int NumberOfRequestsInGroup { get; set; }
        public int ChunkNumber { get; set; }
        public int NumberOfChunks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Route Route { get; set; }
        public string Data { get; set; }
    }
}

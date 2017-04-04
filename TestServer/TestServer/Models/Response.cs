using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public enum ResponseStatus
    {
        Passed,
        Failed,
        Error,
        Partial
    }

    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string Id { get; set; }
        public string SourceId { get; set; }
        public string GroupId { get; set; }
        public int OrderInGroup { get; set; }
        public int NumberofResponsesInGroup { get; set; }
        public int ChunkNumber { get; set; }
        public int NumberOfChunks { get; set; }
        public string Data { get; set; }
    }
}

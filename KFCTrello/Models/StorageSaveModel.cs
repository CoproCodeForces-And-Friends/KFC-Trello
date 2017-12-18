using System;

namespace KFCTrello.Models
{
    public class StorageSaveModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatorId { get; set; }
        public string DeveloperId { get; set; }
        public string[] Labels { get; set; }
        public string ProjectId { get; set; }
        public RelatedIssue[] RelatedIssue { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class RelatedIssue
    {
        public string IssueId { get; set; }
        public string ConnectionType { get; set; } 
    }
}
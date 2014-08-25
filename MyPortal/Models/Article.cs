using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyPortal.Models
{
    [DataContract]
    public class Article
    {
        [Key]
        [DataMember]
        public int ArticleId { get; set; }

        [Required]
        [DataMember]
        [StringLength(160, MinimumLength = 2)]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Location { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DataMember]
        public System.DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [DataMember]
        public virtual List<Comment> Comments { get; set; }
    }

    [DataContract]
    public class Comment
    {
        [Key]
        [DataMember]
        public int CommentId { get; set; }

        [DisplayName("Comment")]
        [Required]
        [StringLength(1024, MinimumLength = 2)]
        [DataMember]
        public string Content { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DataMember]
        public System.DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public int UserId { get; set; }

    }
}
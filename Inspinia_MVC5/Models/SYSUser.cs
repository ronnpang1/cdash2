namespace Inspinia_MVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSUser")]
    public partial class SYSUser
    {
        public int SYSUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordEncryptedText { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }

        public int RowCreatedSYSUserID { get; set; }

        public DateTime? RowCreatedDateTime { get; set; }

        public int RowModifiedSYSUserID { get; set; }

        public DateTime? RowModifiedDateTime { get; set; }
    }
}

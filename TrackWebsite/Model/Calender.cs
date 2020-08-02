namespace TrackWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;

    [Table("Calander")]
    public partial class Calender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SymptomID { get; set; }

        [Required (ErrorMessage ="Please enter symptom title")] 
        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string ThemeColour { get; set; }
    }
}

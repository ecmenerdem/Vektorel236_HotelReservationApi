using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity.Base
{
    public class BaseEntity
    {
        //public BaseEntity()
        //{
        //    GUID=Guid.NewGuid();
        //}

        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Guid GUID { get; set; }=Guid.NewGuid();

        //[DefaultValue(true)]
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

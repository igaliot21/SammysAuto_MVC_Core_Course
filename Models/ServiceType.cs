using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        [MaxLength(512)]
        [Required]
        public string Name { get; set; }
        public ServiceType(){}
        public ServiceType(string Name)
        {
            this.Name = Name;
        }
    }
}
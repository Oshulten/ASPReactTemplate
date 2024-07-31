using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public record CustomDataTypeDTO(string? DataString)
    {
        public static explicit operator CustomDataTypeDTO(CustomDataType data)
        {
            return new CustomDataTypeDTO(data.DataString);
        }
        
        public static explicit operator CustomDataType(CustomDataTypeDTO dto)
        {
            return new CustomDataType(dto.DataString);
        }
    }
}
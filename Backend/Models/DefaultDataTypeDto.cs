using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public record DefaultDataTypeDto(string? DataString)
    {
        public static explicit operator DefaultDataTypeDto(DefaultDataType data)
        {
            return new DefaultDataTypeDto(data.DataString);
        }

        public static explicit operator DefaultDataType(DefaultDataTypeDto dto)
        {
            return new DefaultDataType(dto.DataString);
        }
    }
}
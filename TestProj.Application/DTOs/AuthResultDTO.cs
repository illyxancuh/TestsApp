using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Application.DTOs
{
    public class AuthResultDTO
    {
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}

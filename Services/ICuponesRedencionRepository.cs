using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public interface ICuponesRedencionRepository
    {
        void CrearRedencion(Redencion redencion);
    }
}
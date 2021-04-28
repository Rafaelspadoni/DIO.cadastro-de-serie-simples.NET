using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> lista();    
        T RetornaPorId(int Id);
        void Insere(T entidade);
        void Exclui(int Id);
        void Atualiza(int id, T entidade);
        int proximoId(); 
    }
}
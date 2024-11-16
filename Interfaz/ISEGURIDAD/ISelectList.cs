using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface ISelectList
    {
        public Task<SelectList> GrupoModuloSelectList(Guid id, Guid? idValor);
        public Task<SelectList> ModuloSelectList(Guid id);
        public Task<SelectList> EmpresaSelectList(bool status);
        public Task<SelectList> RolSelectList(bool status);
        public Task<SelectList> TipoEmpresaSelectList(bool status, Guid? idValor);
        public Task<SelectList> TipoPagoSelectList(bool status, Guid? idValor);
        public Task<SelectList> TipoContratoSelectList(bool status, Guid? idValor);

    }
}

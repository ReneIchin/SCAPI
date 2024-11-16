using Microsoft.AspNetCore.Mvc.Rendering;
using SCAPI.Controllers;
using SCAPI.Interfaz.ISEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class SelectService : ISelectList
    {
        private readonly IGruposModulos _grupoModulo;
        private readonly IModulos _modulo;
        private readonly IEmpresas _empresa;
        private readonly IRol _rol;
        private readonly ITiposEmpresas _tipoEmpresa;
        private readonly ITiposPagos _tipoPago;
        private readonly ITipoContrato _tipoContrato;

        public SelectService(IGruposModulos gruposModulos, IModulos modulos, IEmpresas empresa, IRol rol, ITiposEmpresas tiposEmpresas, ITiposPagos tiposPagos, ITipoContrato tipoContrato)
        {
            _grupoModulo = gruposModulos;
            _modulo = modulos;
            _empresa = empresa;
            _rol = rol;
            _tipoEmpresa = tiposEmpresas;
            _tipoPago = tiposPagos;
            _tipoContrato = tipoContrato;
        }

        public async Task<SelectList> GrupoModuloSelectList(Guid id, Guid? idValor)
        {
            var gruposModulos = await _grupoModulo.GetGruposModulos(id, true);

            if (gruposModulos == null || !gruposModulos.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value="" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaGruposModulos = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value="" }
            };

            listaGruposModulos.AddRange(gruposModulos.Select(x => new SelectListItem
            {
                Text = x.GRUPO_MODULO ?? "N/A",
                Value = x.GRUPO_MODULO_ID.ToString()
            }));

            if (idValor != Guid.Empty)
            {
                //es valido
                return new SelectList(listaGruposModulos, "Value", "Text", idValor);
            }

            return new SelectList(listaGruposModulos, "Value", "Text");
        }


        public async Task<SelectList> ModuloSelectList(Guid id)
        {
            var modulos = await _modulo.GetModulosAllGPO(id);

            if (modulos == null || !modulos.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaModulos = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaModulos.AddRange(modulos.Select(x => new SelectListItem
            {
                Text = x.MODULO ?? "N/A",
                Value = x.MODULO_ID.ToString()
            }));

            return new SelectList(listaModulos, "Value", "Text");
        }

        public async Task<SelectList> EmpresaSelectList(bool status)
        {
            var empresas = await _empresa.GetEmpresas(status);

            if (empresas == null || !empresas.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaEmpresas = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaEmpresas.AddRange(empresas.Select(x => new SelectListItem
            {
                Text = x.EMPRESA ?? "N/A",
                Value = x.EMPRESA_ID.ToString()
            }));

            return new SelectList(listaEmpresas, "Value", "Text");
        }

        public async Task<SelectList> RolSelectList(bool status)
        {
            var roles = await _rol.GetRolAll(status);

            if (roles == null || !roles.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaRol = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaRol.AddRange(roles.Select(x => new SelectListItem
            {
                Text = x.ROL ?? "N/A",
                Value = x.ROL_ID.ToString()
            }));

            return new SelectList(listaRol, "Value", "Text");
        }



        public async Task<SelectList> TipoEmpresaSelectList(bool status, Guid? idValor)
        {
            var tipoEmpresa = await _tipoEmpresa.GetTiposEmpresas(status);

            if (tipoEmpresa == null || !tipoEmpresa.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaTipoEmpresa = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaTipoEmpresa.AddRange(tipoEmpresa.Select(x => new SelectListItem
            {
                Text = x.TIPO_EMPRESA ?? "N/A",
                Value = x.TIPO_EMPRESA_ID.ToString()
            }));


            if (idValor != Guid.Empty)
            {
                //es valido
                return new SelectList(listaTipoEmpresa, "Value", "Text", idValor);
            }
            return new SelectList(listaTipoEmpresa, "Value", "Text");

        }
        public async Task<SelectList> TipoPagoSelectList(bool status, Guid? idValor)
        {
            var tipoPagos = await _tipoPago.GetTiposPagos(status);

            if (tipoPagos == null || !tipoPagos.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaTipoPagos = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaTipoPagos.AddRange(tipoPagos.Select(x => new SelectListItem
            {
                Text = x.TIPO_PAGO ?? "N/A",
                Value = x.TIPO_PAGO_ID.ToString()
            }));

            if (idValor != Guid.Empty)
            {
                //es valido
                return new SelectList(listaTipoPagos, "Value", "Text", idValor);
            }
            return new SelectList(listaTipoPagos, "Value", "Text");
        }
        public async Task<SelectList> TipoContratoSelectList(bool status, Guid? idValor)
        {
            var tipoContrato = await _tipoContrato.GetTipoContratos(status);

            if (tipoContrato == null || !tipoContrato.Any())
            {
                var listaVacia = new List<SelectListItem>
                {
                    new SelectListItem { Text = "No hay datos disponibles", Value = "" }
                };

                return new SelectList(listaVacia, "Value", "Text");
            }

            var listaTipoContratos = new List<SelectListItem>
            {
                new SelectListItem { Text = "Selecciona una Opcion", Value = "" }
            };

            listaTipoContratos.AddRange(tipoContrato.Select(x => new SelectListItem
            {
                Text = x.TIPO_CONTRATO ?? "N/A",
                Value = x.TIPO_CONTRATO_ID.ToString()
            }));

            if (idValor != Guid.Empty)
            {
                //es valido
                return new SelectList(listaTipoContratos, "Value", "Text", idValor);
            }
            return new SelectList(listaTipoContratos, "Value", "Text");
        }




    }
}

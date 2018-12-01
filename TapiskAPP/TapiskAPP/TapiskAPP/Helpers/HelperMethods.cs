using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TapiskAPP.Data;

namespace TapiskAPP.Helpers
{
    public static class HelperMethods
    {
        static public async Task Delete(int id, string message,string controller, IPageDialogService dialogService)
        {
            var gree = await dialogService.DisplayAlertAsync("Alerta", message, "Eliminar", "Cancelar");
            if (gree)
            {
                var response = await new RestService().Delete(controller, id);
                if (response != null && response.IsSuccess == true)
                {
                    await dialogService.DisplayAlertAsync("Info", "Los datos han sido eliminados exitosamente", "Ok");
                    return;
                }
                await dialogService.DisplayAlertAsync("Info", "Un error ha ocurrido al intentar eliminar el registro", "Ok");
            }
        }
    }
}

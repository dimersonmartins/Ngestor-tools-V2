using NgestorFieldServiceTools.App;
using NgestorFieldServiceTools.Http.Controllers.Stock;

namespace NgestorFieldServiceTools.Http.Controllers.Service
{
    class IndexServiceController
    {
        public async void execute()
        {
            ControllerNetHome controllerNetHome = new ControllerNetHome();
            controllerNetHome.execute();
            switch (Config.id_operadora_servidor)
            {
                case 1:
                    ControllerActiviaClaro controllerActiviaClaro = new ControllerActiviaClaro();
                    await controllerActiviaClaro.execute();
                    break;
                case 2:
                    ControllerFieldWanet01 controllerFieldWanet01 = new ControllerFieldWanet01();
                    await controllerFieldWanet01.execute();
                    break;
                case 3:
                    ControllerFieldWanet03 controllerFieldWanet03 = new ControllerFieldWanet03();
                    await controllerFieldWanet03.execute();
                    break;
                case 4:
                    ControllerNetfsActivia8080 controllerNetfsActivia8080 = new ControllerNetfsActivia8080();
                    await controllerNetfsActivia8080.execute();
                    break;
            }
        }
    }
}

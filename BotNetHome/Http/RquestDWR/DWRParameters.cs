using BotNetHome.App;

namespace BotNetHome.Http.RequestDWR
{
    class DWRParameters
    {
        public string KEYSESSION { get; set; }
        public string DWRKEYSESSION { get; set; }
        public string JSESSIONID { get; set; }

        #region varParamDWR
        public string param01 = "callCount=1";
        public string param02 = "httpSessionId="; // JSONSESSION
        public string param03 = "scriptSessionId=";
        public string param04 = "page=/nethome/equipamento/relatorioEquipamentos.do";
        public string param05 = "c0-scriptName=BaseDWR";
        public string param06 = "c0-methodName=executeService";
        public string param07 = "c0-id="; //ID_HANDLE_RESPONSE
        public string param08 = "c0-param0=string:NetHomeEquipamentoService.relatorioEquipamentosAnaliticoExportacaoTaskV2";
        public string param09 = "c0-e2=string:br.com.netservicos.framework.core.bean.DynamicBean";
        public string param10 = "c0-e5=string:idOperacao";
        public string param11 = "c0-e6=string:java.lang.String";
        public string param12 = "c0-e7=string:"; //idOperacao
        public string param13 = "c0-e4=Object:{name:reference:c0-e5, type:reference:c0-e6, value:reference:c0-e7}";
        public string param14 = "c0-e9=string:idTipoLocalizacao";
        public string param15 = "c0-e10=string:java.lang.Long";
        public string param16 = "c0-e11=string:"; //idTipoLocalizacao
        public string param17 = "c0-e8=Object:{name:reference:c0-e9, type:reference:c0-e10, value:reference:c0-e11}";
        public string param18 = "c0-e13=string:idLocalizacao";
        public string param19 = "c0-e14=string:java.lang.Long";
        public string param20 = "c0-e15=string:"; //Código Atlas //idLocalizacao
        public string param21 = "c0-e12=Object:{name:reference:c0-e13, type:reference:c0-e14, value:reference:c0-e15}";
        public string param22 = "c0-e17=string:idTipoEquipamento";
        public string param23 = "c0-e18=string:java.lang.Long";
        public string param24 = "c0-e19=string:"; //idTipoEquipamento
        public string param25 = "c0-e16=Object:{name:reference:c0-e17, type:reference:c0-e18, value:reference:c0-e19}";
        public string param26 = "c0-e21=string:idEstadoEquipamento";
        public string param27 = "c0-e22=string:java.lang.Long";
        public string param28 = "c0-e23=string:"; //idEstadoEquipamento
        public string param29 = "c0-e20=Object:{name:reference:c0-e21, type:reference:c0-e22, value:reference:c0-e23}";
        public string param30 = "c0-e25=string:idSubTipoEquipamento";
        public string param31 = "c0-e26=string:java.lang.String";
        public string param32 = "c0-e27=string:"; //idSubTipoEquipamento
        public string param33 = "c0-e24=Object:{name:reference:c0-e25, type:reference:c0-e26, value:reference:c0-e27}";
        public string param34 = "c0-e29=string:idClassificacao";
        public string param35 = "c0-e30=string:java.lang.String";
        public string param36 = "c0-e31=string:"; //idClassificacao
        public string param37 = "c0-e28=Object:{name:reference:c0-e29, type:reference:c0-e30, value:reference:c0-e31}";
        public string param38 = "c0-e33=string:idEmpresa";
        public string param39 = "c0-e34=string:java.lang.String";
        public string param40 = "c0-e35=string:"; //idEmpresa
        public string param41 = "c0-e32=Object:{name:reference:c0-e33, type:reference:c0-e34, value:reference:c0-e35}";
        public string param42 = "c0-e37=string:typeDam";
        public string param43 = "c0-e38=string:java.lang.String";
        public string param44 = "c0-e39=string:"; //typeDam
        public string param45 = "c0-e36=Object:{name:reference:c0-e37, type:reference:c0-e38, value:reference:c0-e39}";
        public string param46 = "c0-e3=Array:[reference:c0-e4,reference:c0-e8,reference:c0-e12,reference:c0-e16,reference:c0-e20,reference:c0-e24,reference:c0-e28,reference:c0-e32,reference:c0-e36]";
        public string param47 = "c0-e1=Object:{type:reference:c0-e2, value:reference:c0-e3}";
        public string param48 = "c0-param1=Array:[reference:c0-e1]";
        public string param49 = "c0-param2=null:null";
        public string param50 = "c0-param3=null:null";
        #endregion

        public string baseDWR()
        {
            string baseDWR =
                param01 + "\r\n" +
                param02 + JSESSIONID + "\r\n" +
                param03 + DWRKEYSESSION + "\r\n" +
                param04 + "\r\n" +
                param05 + "\r\n" +
                param06 + "\r\n" +
                param07 + KEYSESSION + "\r\n" +
                param08 + "\r\n" +
                param09 + "\r\n" +
                param10 + "\r\n" +
                param11 + "\r\n" +
                param12 + Config.CODIGO_OPERACAO + "\r\n" +
                param13 + "\r\n" +
                param14 + "\r\n" +
                param15 + "\r\n" +
                param16 + Config.CODIGO_LOCALIZACAO + "\r\n" +
                param17 + "\r\n" +
                param18 + "\r\n" +
                param19 + "\r\n" +
                param20 + Config.CODIGO_ATLAS + "\r\n" +
                param21 + "\r\n" +
                param22 + "\r\n" +
                param23 + "\r\n" +
                param24 + "\r\n" +
                param25 + "\r\n" +
                param26 + "\r\n" +
                param27 + "\r\n" +
                param28 + "\r\n" +
                param29 + "\r\n" +
                param30 + "\r\n" +
                param31 + "\r\n" +
                param32 + "\r\n" +
                param33 + "\r\n" +
                param34 + "\r\n" +
                param35 + "\r\n" +
                param36 + "\r\n" +
                param37 + "\r\n" +
                param38 + "\r\n" +
                param39 + "\r\n" +
                param40 + Config.TIPO_FILTRO_OPEARADORA + "\r\n" +
                param41 + "\r\n" +
                param42 + "\r\n" +
                param43 + "\r\n" +
                param44 + "\r\n" +
                param45 + "\r\n" +
                param46 + "\r\n" +
                param47 + "\r\n" +
                param48 + "\r\n" +
                param49 + "\r\n" +
                param50 + "\r\n";
            return baseDWR;
        }

    }
}
